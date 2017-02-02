using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.Net;
namespace LinkParser
{
    //the class send mail then occure error in programm, for example occure exception

    class MailSender:ISmtpSender
    {
        private SmtpClient _client;
        private MailMessage _mail;
        private int _allow;
        public MailSender()
        {
            int port;
            NetworkCredential basicCredential = new NetworkCredential("stoloto-bot", "123qq123qq");
            _mail = new MailMessage(ConfigurationManager.AppSettings["MailFrom"], ConfigurationManager.AppSettings["MailTo"], ConfigurationManager.AppSettings["MailSubject"], ConfigurationManager.AppSettings["MailBody"]);
            _mail.BodyEncoding = System.Text.Encoding.UTF8;
            _client = new SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
            int.TryParse(ConfigurationManager.AppSettings["MailPort"], out port);
            _client.Port = port;
            int.TryParse(ConfigurationManager.AppSettings["Allow"], out _allow);
            _client.EnableSsl = true;
            _client.UseDefaultCredentials = false;
            _client.Credentials = basicCredential;
            _mail.IsBodyHtml = true;
            //_client.Timeout = 1000;
        }

        public void SendMail(string message, string game)
        {

            if(_allow==1)
                try
                {
                    _mail.Body ="<h1>"+game+"</h1><br>"+ message;
                    _client.Send(_mail);
                    //Console.WriteLine("{0} data sent to email", game);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR send e-mail:" + e.Message);
                }
        }
    }
}
