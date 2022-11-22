using LoginService.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Text;

namespace LoginService.Services
{
    public class EmailService : IEmailService
    {
        private const string templatepath = @"EmailTemplate/{0}.html";

        public SMTPConfig Smtpconfig { get; }

        public async Task SendTestEmail(UserEmail email,int? roleid,int purpose)
        {

            if (roleid == 4 && purpose== 301)
            {
                email.Subject = "Welcome to CT Hospital";
                email.Body = GetEmailBody("welcomepatient");
            }
            else if (purpose == 302)
            {
                email.Subject = "CT Hospital | User Registration-Change Password";
                email.Body = GetEmailBody("welcomehospuser");
            }
            else if (purpose == 303)
            {
                email.Subject = "CT Hospital | Reset your CT Hospital Password";
                email.Body = GetEmailBody("ResetPassword");
            }
            else if (purpose == 304)
            {
                email.Subject = "CT Hospital | Your account has been Activated";
                email.Body = GetEmailBody("ActivateAccount");
            }
            else if (purpose == 305)
            {
                email.Subject = "CT Hospital | Your Account has been Blocked";
                email.Body = GetEmailBody("BlockedAccount");
            }

            await SendEmail(email);
        }

        public EmailService(IOptions<SMTPConfig> smtpconfig)
        {
            Smtpconfig = smtpconfig.Value;
        }
        private async Task SendEmail(UserEmail userEmail)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmail.Subject,
                Body = userEmail.Body,
                From = new MailAddress(Smtpconfig.SenderAddress, Smtpconfig.SenderDisplayName),
                IsBodyHtml = Smtpconfig.IsBodyHTML,
            };

            foreach (var email in userEmail.ToEmail)
            {
                mail.To.Add(email);
            }

            NetworkCredential networkCredential = new NetworkCredential(Smtpconfig.UserName, Smtpconfig.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = Smtpconfig.Host,
                Port = Smtpconfig.Port,
                EnableSsl = Smtpconfig.EnableSSL,
                UseDefaultCredentials = Smtpconfig.UseDefaultCredentials,
                Credentials = networkCredential
            };


            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);


        }

        private string GetEmailBody(string template)
        {
            var body = File.ReadAllText(string.Format(templatepath, template));
            return body;
        }

    }
}
