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

        [HttpPut]
        public IActionResult Put(PurchaseModel purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingPurchase = _ctx.Purchases.Where(pu => pu.AppCatalogueId == purchase.AppCatalogueId && pu.StoreUserId == purchase.StoreUserId).FirstOrDefault();
            if (existingPurchase != null)
            {
                existingPurchase.CreatedAt = purchase.CreatedAt;

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
            var purchase = _ctx.Purchases.Find(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _ctx.Purchases.Remove(purchase);
            _ctx.SaveChanges();
            return Ok("Elemento eliminato correttamente");
        }
    }
}
