using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Assicurati di usare il namespace corretto per ILogger
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        // POST: api/StoreUser/CheckUsername
        [HttpPost]
        [Route("CheckUsername")]
        public IActionResult CheckUsername([FromBody] string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username non valido.");
            }

            var existingUser = _ctx.Users.FirstOrDefault(u => u.NickName == username);
            if (existingUser != null)
            {
                return Ok(new { isUsernameTaken = true });
            }

            return Ok(new { isUsernameTaken = false });
        }


        // POST: api/StoreUser/Register
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] StoreUserModel storeUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Check if username already exists
                var existingUser = _ctx.Users.FirstOrDefault(u => u.NickName == storeUser.NickName);
                if (existingUser != null)
                {
                    return Conflict(new { isUsernameTaken = true });
                }

                // Create new StoreUser entity and save to database
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Users.ToList();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(StoreUserModel storeUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingStoreUser = _ctx.Users.FirstOrDefault(u => u.StoreUserId == storeUser.Id);
            if (existingStoreUser != null)
            {
                existingStoreUser.NickName = storeUser.NickName;

                _ctx.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var storeUser = _ctx.Users.Find(id);
            if (storeUser == null)
            {
                return NotFound();
            }

            _ctx.Users.Remove(storeUser);
            _ctx.SaveChanges();
            return Ok("Elemento eliminato correttamente");
        }
    }
}