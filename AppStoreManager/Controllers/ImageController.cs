using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet("{imageName}")]
        public async Task<IActionResult> GetImage(string imageName)
        {
            // Percorso fisico dell'immagine
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

            // Verifica se il file esiste
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            // Ottieni il tipo di contenuto dell'immagine
            var contentType = GetContentType(path);

            return File(memory, contentType, Path.GetFileName(path));
        }

        private string GetContentType(string path) 
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".png", "image/png"},
                {".gif", "image/gif"}
            };
        }
    }
}
