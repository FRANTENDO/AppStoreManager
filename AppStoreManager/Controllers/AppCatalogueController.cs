using AppStoreManager.Data;
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
            var result = apps.ConvertAll<AppModel>(a => new AppModel() {
                Id = a.AppCatalogueId,
                CategoryId = a.CategoryId,
                Category = a.Category?.Name ?? "Categoria non disponibile",
                Description = a.Description,
                Title = a.Title,
                Price = a.Price
            });
            return Ok(result);
        }
    }
}
