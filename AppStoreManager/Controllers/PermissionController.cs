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
    }
}
