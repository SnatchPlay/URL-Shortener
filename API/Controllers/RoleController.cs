using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace URL_Shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private IRoleService service= new RoleService();

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;

        }
        [HttpGet]
        public List<Role> Get()
        {
            return service.GetAllRoles();
        }
    }
}
