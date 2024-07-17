using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppCatalogueController : ControllerBase
    {
        private readonly ILogger<AppCatalogueController> _logger;
        private readonly AppManagerDbContext _ctx;
        private readonly IWebHostEnvironment _environment;

        public AppCatalogueController(AppManagerDbContext ctx, ILogger<AppCatalogueController> logger, IWebHostEnvironment environment)
        {
            _ctx = ctx;
            _logger = logger;
            _environment = environment;
        }

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
                Price = a.Price,
                IconPath = a.IconPath
            });
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(AppModel app)
        {
            try
            {
                if (app.Icon != null)
                    System.IO.File.WriteAllBytes($"wwwroot/images/{app.IconPath}", app.Icon);
                else
                    app.IconPath = "default.png";
                AppCatalogue newItem = new AppCatalogue()
                {
                    AppCatalogueId = app.Id,
                    CategoryId = app.CategoryId,
                    Description = app.Description,
                    Title = app.Title,
                    Price = app.Price,
                    IconPath = app.IconPath
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
                existingApp.IconPath = app.IconPath;

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

        // Metodo per caricare l'icona
        [HttpPost("{id}/upload-icon")]
        public async Task<IActionResult> UploadIcon(int id, IFormFile file)
        {
            var app = await _ctx.AppCatalogues.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            app.IconPath = $"/uploads/{file.FileName}";
            _ctx.AppCatalogues.Update(app);
            await _ctx.SaveChangesAsync();

            return Ok(new { filePath = app.IconPath });
        }

        // Metodo per ottenere l'icona
        [HttpGet("{id}/icon")]
        public IActionResult GetIcon(int id)
        {
            var app = _ctx.AppCatalogues.Find(id);
            if (app == null || string.IsNullOrEmpty(app.IconPath))
            {
                return NotFound();
            }

            var filePath = Path.Combine(_environment.WebRootPath, app.IconPath.TrimStart('/'));
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "image/jpeg");
        }
    }
}
