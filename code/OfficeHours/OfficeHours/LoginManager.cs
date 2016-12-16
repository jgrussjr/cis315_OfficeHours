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
            myDB = new LoginManagerDataContext("Data Source=SEDEV2\\OFFICEHOURS;Initial Catalog=Appointments;Integrated Security=True");
        }

        public string[] createNewUser(String firstName, String lastName, String emailAddress, String password)
        {
            string returnMessage = string.Empty;
            var checkDuplicate = from user in myDB.logins
                                 where user.emailAddress == emailAddress select user;

            string[] dups = new string[2] { "duplicate", ""};
            if (checkDuplicate.Count() != 0)
                return dups;

            login newRecord = new login();
            Byte[] salt = new Byte[128];

            newRecord.firstName = firstName;
            newRecord.lastName = lastName;
            newRecord.emailAddress = emailAddress;
            rngCsp.GetBytes(salt);
            newRecord.passwordSalt = salt;
            byte[] saltedPass = salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            newRecord.hashPassword = mySHA256.ComputeHash(saltedPass);

            myDB.logins.InsertOnSubmit(newRecord);
            try
            { 
                myDB.SubmitChanges(); 
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                string thing = e.ToString();
                string[] exc = new string[2] { "exception", "Problem adding record to database" };
                return exc;
            }
            
            string[] good = new string[2] { "true", "" };
            return good;
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
            login user = new login();
            try
            {
                user = myDB.logins.Single(u => u.emailAddress.ToString().Equals(emailAddress));
            }
            catch (Exception ex)
            {
                return false;
            }
            if (user != null)
            {
                // There (was) something wrong going on in here. Causing a null object error
                    byte[] realSalt = user.passwordSalt.ToArray();

                    byte[] testHash = mySHA256.ComputeHash(realSalt.Concat(Encoding.UTF8.GetBytes(password)).ToArray());

                    byte[] realHash = user.hashPassword.ToArray();

                    return ((testHash).SequenceEqual(realHash));
            }
            else
            {
                return false;
            }
        }
        
    }
}