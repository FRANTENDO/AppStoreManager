using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController(AppManagerDbContext ctx, ILogger<PurchaseController> logger) : ControllerBase
    {
        private ILogger<PurchaseController> _logger = logger;
        private readonly AppManagerDbContext _ctx = ctx;

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Purchases.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(PurchaseModel purchase)
        {
            try
            {
                Purchase newItem = new Purchase()
                {
                    AppCatalogueId = purchase.AppCatalogueId,
                    StoreUserId = purchase.StoreUserId,
                    CreatedAt = purchase.CreatedAt
                };
                _ctx.Purchases.Add(newItem);
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
