using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace CAFEDataInterface
{
    public class LoginManager
    {
        private LoginManagerDataContext myDB;
        private static SHA256 mySHA256 = new SHA256Managed();
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public LoginManager()
        {
            myDB = new LoginManagerDataContext("Data Source=SEDEV2\\OFFICEHOURS;Initial Catalog=CAFE;Integrated Security=True");
        }

        public bool createNewUser(String firstName, String lastName, String emailAddress, String password)
        {
            var checkDuplicate = from user in myDB.logins
                                 where user.emailAddress == emailAddress select user;

            if (checkDuplicate.Count() != 0)
                return false;

            login newRecord = new login();
            Byte[] salt = new Byte[128];

            newRecord.firstName = firstName;
            newRecord.lastName = lastName;
            newRecord.emailAddress = emailAddress;
            rngCsp.GetBytes(salt);
            newRecord.passwordSalt = salt;
            byte[] saltedPass = salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            newRecord.passwordHash = mySHA256.ComputeHash(saltedPass);

            myDB.logins.InsertOnSubmit(newRecord);
            try
            {
                myDB.SubmitChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public bool deleteUser(String emailAddress)
        {
            var usersToDelete = from user in myDB.logins
                                where user.emailAddress == emailAddress
                                select user;

            if (usersToDelete.Count() == 0)
                return false;

            foreach (var user in usersToDelete)
            {
                myDB.logins.DeleteOnSubmit(user);
            }

            try
            {
                myDB.SubmitChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public bool checkPassword(String emailAddress, String password)
        {
            login user = myDB.logins.Single(u => u.emailAddress == emailAddress);

            byte[] realSalt = user.passwordSalt.ToArray();

            byte[] testHash = mySHA256.ComputeHash(realSalt.Concat(Encoding.UTF8.GetBytes(password)).ToArray());

            byte[] realHash = user.passwordHash.ToArray();

            return (testHash.SequenceEqual(realHash));
        }
    }
}