using ENIMS.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common
{
	public class EmailSenderService : IEmailSender
	{
		private readonly Settings _emailSettings;
		public EmailSenderService(IOptions<Settings> emailSettings)
		{
			_emailSettings = emailSettings.Value;
		}
		public Task SendEmailAsync(string message, string subject, string[] toAddress, string[] ccAddress, string[] attachements)
		{
			Execute(message, subject, toAddress, ccAddress, attachements).Wait();
			return Task.FromResult(0);
		}
		public async Task Execute(string message, string subject, string[] toAddress, string[] ccAddress, string[] attachements)
		{
            try
            {
				if (toAddress == null && ccAddress == null)
					return;

				MailMessage mail = new MailMessage()
				{
					From = new MailAddress(_emailSettings.EmailSettings.Sender, Keys.EMAIL_SUBJECT)
				};

				if (toAddress != null)
				{
					foreach (var to in toAddress)
						mail.To.Add(new MailAddress(to));
				}

				if (ccAddress != null)
				{
					foreach (var cc in ccAddress)
						mail.CC.Add(new MailAddress(cc));
				}

				if (attachements != null)
				{
					foreach (var fileName in attachements)
						mail.Attachments.Add(new Attachment(fileName));
				}

				mail.Subject = subject;
				mail.Body = message;
				mail.IsBodyHtml = true;
				mail.Priority = MailPriority.Normal;

				using (SmtpClient smtp = new SmtpClient(_emailSettings.EmailSettings.MailServer, _emailSettings.EmailSettings.MailPort))
				{
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = new NetworkCredential(_emailSettings.EmailSettings.Sender, _emailSettings.EmailSettings.Password);
					smtp.Host = _emailSettings.EmailSettings.MailServer;
					smtp.Port = _emailSettings.EmailSettings.MailPort;
					smtp.EnableSsl = true;
					await smtp.SendMailAsync(mail);
				}
			}
            catch (Exception ex)
            {

            }

		}
	}
}
