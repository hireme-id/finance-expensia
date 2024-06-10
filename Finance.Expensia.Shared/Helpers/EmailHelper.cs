using Finance.Expensia.Shared.Objects;
using System.Net;
using System.Net.Mail;

namespace Finance.Expensia.Shared.Helpers
{
	public static class EmailHelper
	{
		public static void SendEmail(EmailData input)
		{
			try
			{
				// Define the email parameters
				var fromAddress = new MailAddress(input.FromEmail, input.FromDisplayName);
				var toAddress = new MailAddress(input.ToEmail, input.ToDisplayName);

				// Configure the SMTP client
				var smtp = new SmtpClient
				{
					Host = "smtp.gmail.com", // Set your SMTP server here
					Port = 587, // Adjust the port if necessary (usually 587 for TLS, 465 for SSL)
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(fromAddress.Address, input.PasswordEmail)
				};

				// Create the email message
				using var message = new MailMessage(fromAddress, toAddress)
				{
					Subject = input.SubjectEmail,
					Body = input.BodyEmail,
					IsBodyHtml = true // Set the body to be HTML
				};

				// Send the email
				smtp.Send(message);

				Console.WriteLine("HTML email sent successfully!");
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void SendEmailMultiReceiver(EmailData input)
		{
			try
			{
				// Define the email parameters
				var fromAddress = new MailAddress(input.FromEmail, input.FromDisplayName);

				// Configure the SMTP client
				var smtp = new SmtpClient
				{
					Host = "smtp.gmail.com", // Set your SMTP server here
					Port = 587, // Adjust the port if necessary (usually 587 for TLS, 465 for SSL)
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(fromAddress.Address, input.PasswordEmail)
				};

				// Create the email message
				using var message = new MailMessage()
				{
					From = fromAddress,
					Subject = input.SubjectEmail,
					Body = input.BodyEmail,
					IsBodyHtml = true // Set the body to be HTML
				};

				// Add some receiver
				foreach (var receiver in input.MultiRecievers)
				{
					message.To.Add(receiver);
				}

				// Send the email
				smtp.Send(message);

				Console.WriteLine("HTML email sent successfully!");
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
