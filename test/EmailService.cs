using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using test;
using Microsoft.Extensions.Options;
using System.Linq;
using test.Data;

namespace test
{
    public  class EmailService
    {


        public async Task SendEmailAsync(ApplicationDbContext _context, string email, string subject, string message)
        {
            var AP = _context.AppConfig.Where(p => p.Key == "SendEmail").FirstOrDefault();
            var Email = AP.Value;
            AP = _context.AppConfig.Where(p => p.Key == "EmailPassword").FirstOrDefault();
            var Password = AP.Value;
            AP = _context.AppConfig.Where(p => p.Key == "host").FirstOrDefault();
            var Host = AP.Value;
            AP = _context.AppConfig.Where(p => p.Key == "port").FirstOrDefault();
            int port = Int32.Parse(AP.Value);
            AP = _context.AppConfig.Where(p => p.Key == "useSsl").FirstOrDefault();
            bool useSsl = bool.Parse(AP.Value);


            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация приемной комиссии", Email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            
            using (var client = new SmtpClient())
            {

                await client.ConnectAsync(Host, port, useSsl);
                //await client.AuthenticateAsync("vkolodyazhny@yandex.ru", "mfkwwmrjzikuevaq");
                await client.AuthenticateAsync(Email, Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
