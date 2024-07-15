using AppStoreManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public MailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmailAsync([FromBody] MailModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Imposta l'indirizzo email predefinito se il campo To è vuoto
            if (string.IsNullOrWhiteSpace(model.To))
            {
                model.To = "frafio2006@gmail.com";
            }

            try
            {
                // Chiamata al metodo SendEmailAsync dell'IEmailSender per inviare l'email
                await _emailSender.SendEmailAsync(model.To, model.Subject, model.Body);

                return Ok("Email inviata con successo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante l'invio dell'email: {ex.Message}");
            }
        }
    }
}
