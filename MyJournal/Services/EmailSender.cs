﻿using System.Threading.Tasks;

namespace MyJournal.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(Microsoft.Extensions.Options.IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGrid.SendGridClient(apiKey);
            var msg = new SendGrid.Helpers.Mail.SendGridMessage()
            {
                From = new SendGrid.Helpers.Mail.EmailAddress("donutreply@myjournal.co.uk", "My Journal Verification"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new SendGrid.Helpers.Mail.EmailAddress(email));
            var result = await client.SendEmailAsync(msg);
            //if (result.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            // #if DEBUG
            // var error = await result.Body.ReadAsStringAsync();
            //               throw new Exception(error);
            // #else
            //	throw new Exception("Unable to send email!");
            //#endif
            // } 

        }
    }
}
