using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiPro.Models;
using Microsoft.Extensions.Options;
using System.IO;
using MailKit;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;

namespace TaxiPro.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            ExecuteEmail(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task ExecuteEmail(string email, string subject, string message)
        {
            try
            {
                string uEmail = GetEmailInfo().Split("\t")[0];
                string upw = GetEmailInfo().Split("\t")[1];
                var msg = new MimeMessage();
                msg.To.Add(new MailboxAddress(email));
                msg.From.Add(new MailboxAddress("TaxiPro", uEmail));

                msg.Subject = subject;
                msg.Body = new TextPart(TextFormat.Html)
                {
                    Text = message
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(_emailSettings.SecondaryDomain, _emailSettings.SecondaryPort, true);
                    smtp.Authenticate(uEmail, upw);
                    smtp.Send(msg);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                //catch errors here
                string err = ex.Message;
            }
        }

        public string GetEmailInfo()
        {
            string ue = "";
            string upw = "";
            try
            {
                string[] files = Directory.GetFiles(_emailSettings.Dir);
                string file = files[0];
                using (TextReader tr = new StreamReader(file))
                {
                    //string doc = tr.ReadToEnd();
                    string l = " ";
                    while (l != null)
                    {
                        if (l.Contains("UserEmail"))
                        {
                            ue = l.Split(":")[1];
                        }
                        if (l.Contains("UserPassword"))
                        {
                            upw = l.Split(":")[1];
                            
                        }
                        l = tr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();

            }

            return string.Format("{0}\t{1}", ue, upw);
        }
    }
}
