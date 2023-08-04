using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService service = new UserService();
        private IRoleService roleService=new RoleService();
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public void CreateNewUser(string email, string password) 
        {
            service.AddUser(email,roleService.GetRoleById(2), password);
        }
        [HttpGet]
        public bool CheckLogin(string email,string password) 
        {
            return service.CredentialsCheck(email,password);
        }

    }
}
