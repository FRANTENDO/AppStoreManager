using AppStoreManager.Data;
using AppStoreManager.Entities;
using AppStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(AppManagerDbContext ctx, ILogger<PermissionController> logger) : ControllerBase
    {
        private ILogger<PermissionController> _logger = logger;
        private readonly AppManagerDbContext _ctx = ctx;

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Permissions.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(PermissionModel permission)
        {
            try
            {
                permission.Id = 0;
                Permission newItem = new Permission()
                {
                    PermissionId = permission.Id,
                    Name = permission.Name
                };
                _ctx.Permissions.Add(newItem);
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
        public IActionResult Put(PermissionModel permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingPermission = _ctx.Permissions.Where(pe => pe.PermissionId == permission.Id).FirstOrDefault();
            if (existingPermission != null)
            {
                existingPermission.Name = permission.Name;

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
            var permission = _ctx.Permissions.Find(id);
            if (permission == null)
            {
                return NotFound();
            }

            _ctx.Permissions.Remove(permission);
            _ctx.SaveChanges();
            return Ok("Elemento eliminato correttamente");
        }
    }
}
