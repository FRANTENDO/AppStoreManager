using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreUserController(AppManagerDbContext ctx, ILogger<StoreUserController> logger) : ControllerBase
    {
        private ILogger<StoreUserController> _logger = logger;
        private readonly AppManagerDbContext _ctx = ctx;

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
                    NickName = storeUser.NickName
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
    }
}
