using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Assicurati di usare il namespace corretto per ILogger

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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Users.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(StoreUserModel storeUser)
        {
            try
            {
                storeUser.Id = 0;
                StoreUser newItem = new StoreUser()
                {
                    StoreUserId = storeUser.Id,
                    NickName = storeUser.NickName,
                    Password = storeUser.Pass
                };

                _ctx.Users.Add(newItem);
                if (_ctx.SaveChanges() > 0)
                {
                    return Ok("TUTTO A POSTO");
                }
                return BadRequest("CHE MI HAI MANDATO?!?");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "OPS, MI SI è ROTTO IL SERVER");
            }
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

        [HttpPut]
        public IActionResult Put(StoreUserModel storeUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingStoreUser = _ctx.Users.Where(u => u.StoreUserId == storeUser.Id).FirstOrDefault();
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
