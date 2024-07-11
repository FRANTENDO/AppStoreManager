using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(AppManagerDbContext ctx, ILogger<CategoryController> logger) : ControllerBase
    {
        private ILogger<CategoryController> _logger = logger;
        private readonly AppManagerDbContext _ctx = ctx;

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Categories.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CategoryModel category)
        {
            try
            {
                category.Id = 0;
                Category newItem = new Category()
                {
                    CategoryId = category.Id,
                    Name = category.Name
                };
                _ctx.Categories.Add(newItem);
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
