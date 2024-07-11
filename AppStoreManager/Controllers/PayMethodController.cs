using AppStoreManager.Data;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMethodController(AppManagerDbContext ctx, ILogger<PayMethodController> logger) : ControllerBase
    {
        private ILogger<PayMethodController> _logger = logger;
        private readonly AppManagerDbContext _ctx = ctx;

        [HttpGet]
        public IActionResult GetAll()
        {
            var payMethods = _ctx.PayMethods.Include(p => p.StoreUser).ToList();
            var result = payMethods.ConvertAll<PayMethodModel>(p => new PayMethodModel()
            {
                Id = p.PayMethodId,
                Name = p.Name,
                StoreUserId = p.StoreUserId,
                StoreUser = p.StoreUser?.NickName ?? "Nome non disponibile"
            });
            return Ok(result);
        }
    }
}
