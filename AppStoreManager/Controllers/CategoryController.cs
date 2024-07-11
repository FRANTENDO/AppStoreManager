using AppStoreManager.Data;
using AppStoreManager.Entities;
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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly AppManagerDbContext _ctx;

        public CategoryController(AppManagerDbContext ctx, ILogger<CategoryController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

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

        [HttpPut]
        public IActionResult Put(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingCategory = _ctx.Categories.Where(c => c.CategoryId == category.Id).FirstOrDefault();
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;

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
            var category = _ctx.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _ctx.Categories.Remove(category);
            _ctx.SaveChanges();
            return Ok("Elemento eliminato correttamente");
        }
    }
}

