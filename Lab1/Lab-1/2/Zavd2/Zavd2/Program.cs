using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Zavd2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                SmtpClient C = new SmtpClient("mail.univ.net.ua");
                C.Port = 25;
                C.Credentials = new NetworkCredential("ponzel.maksym", "7mn9fcda");
                C.EnableSsl = true;
                C.Send(new MailMessage("ponzel.maksym@univ.net.ua", args[0], args[1], DateTime.Now.ToString() + " Понзель Максим "));
            }
            else
            {
                Console.WriteLine("SYNTAX: Zavd2.exe <ToAddr> <Subject>");
            }
        }
    }
}
