using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreUserController : ControllerBase
    {
        private readonly ILogger<StoreUserController> _logger;
        private readonly AppManagerDbContext _ctx;

        public StoreUserController(AppManagerDbContext ctx, ILogger<StoreUserController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] StoreUserModel storeUser)
        {
            try
            {
                // Crea un nuovo oggetto StoreUser per salvare nel database
                StoreUser newItem = new StoreUser()
                {
                    NickName = storeUser.NickName,
                    Password = storeUser.Pass,
                    FullName = storeUser.FullName,
                    Mail = storeUser.Mail
                };

                _ctx.Users.Add(newItem);
                _ctx.SaveChanges();

                return Ok("Registrazione completata con successo");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la registrazione");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Si è verificato un errore durante la registrazione: {ex.Message}");
            }
        }

    }
}
