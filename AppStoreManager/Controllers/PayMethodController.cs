using AppStoreManager.Data;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMethodController : ControllerBase
    {
        private readonly ILogger<PayMethodController> _logger;
        private readonly AppManagerDbContext _ctx;

        public PayMethodController(AppManagerDbContext ctx, ILogger<PayMethodController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

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

        [HttpPut]
        public IActionResult Put(PayMethodModel payMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingPayMethod = _ctx.PayMethods.Where(pm => pm.PayMethodId == payMethod.Id).FirstOrDefault();
            if (existingPayMethod != null)
            {
                existingPayMethod.Name = payMethod.Name;
                existingPayMethod.StoreUserId = payMethod.StoreUserId;

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
            var payMethod = _ctx.PayMethods.Find(id);
            if (payMethod == null)
            {
                return NotFound();
            }

            _ctx.PayMethods.Remove(payMethod);
            _ctx.SaveChanges();
            return Ok("Elemento eliminato correttamente");
        }
    }
}
