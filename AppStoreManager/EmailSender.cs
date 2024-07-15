using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AppStoreManager
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("pctoappstoremanagermail@gmail.com", "xhpx ipsk mytq yehv "),
                    EnableSsl = true
                };

                return client.SendMailAsync(
                    new MailMessage("pctoappstoremanagermail@gmail.com", email, subject, message)
                    {
                        IsBodyHtml = true // Imposta a true se il messaggio è in formato HTML
                    }
                );
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni qui
                throw new InvalidOperationException($"Errore durante l'invio dell'email: {ex.Message}", ex);
            }
        }
    }
}
