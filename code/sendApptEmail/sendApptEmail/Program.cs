using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendApptEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            emailSender es = new emailSender();

            es.Sendmail_With_IcsAttachment();
        }
    }
}
