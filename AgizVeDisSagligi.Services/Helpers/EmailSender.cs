using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace AgizVeDisSagligi.Services.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly IWebHostEnvironment env;

        public EmailSender(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "fatih.fe205@gmail.com";
            var pw = "dhuv viyt xnnr doey";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };


            var mailMessage =
                new MailMessage(
                from: mail,
                to: email,
                subject: subject,
                body: message)
                {
                    IsBodyHtml = true
                };

            return client.SendMailAsync(mailMessage);


        }
    }
}
