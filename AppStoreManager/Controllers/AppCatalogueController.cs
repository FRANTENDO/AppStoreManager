using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppCatalogueController(AppManagerDbContext ctx, ILogger<AppCatalogueController> logger) : ControllerBase
    {
        private ILogger<AppCatalogueController> _logger = logger;
        private readonly AppManagerDbContext _ctx = ctx;

        [HttpGet]
        public IActionResult GetAll()
        {
            var apps = _ctx.AppCatalogues.Include(a => a.Category).ToList();
            var result = apps.ConvertAll<AppModel>(a => new AppModel()
            {
                Id = a.AppCatalogueId,
                CategoryId = a.CategoryId,
                Category = a.Category?.Name ?? "Categoria non disponibile",
                Description = a.Description,
                Title = a.Title,
                Price = a.Price
            });
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(AppModel app)
        {
            try
            {
                AppCatalogue newItem = new AppCatalogue()
                {
                    AppCatalogueId = app.Id,
                    CategoryId = app.CategoryId,
                    Description = app.Description,
                    Title = app.Title,
                    Price = app.Price
                };
                _ctx.AppCatalogues.Add(newItem);
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
        public IActionResult Put(AppModel app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingApp = _ctx.AppCatalogues.Where(a => a.AppCatalogueId == app.Id).FirstOrDefault();
            if (existingApp != null)
            {
                existingApp.CategoryId = app.CategoryId;
                existingApp.Description = app.Description;
                existingApp.Title = app.Title;
                existingApp.Price = app.Price;

                _ctx.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var app = _ctx.AppCatalogues.Find(id);
            if (app == null)
            {
                return NotFound();
            }

            _ctx.AppCatalogues.Remove(app);
            _ctx.SaveChanges();
            return Ok("Elemento eliminato correttamente");
        }
    }
}
