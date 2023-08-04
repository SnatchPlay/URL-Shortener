using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.DTO;

namespace URL_Shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService service = new UserService();
        private IRoleService roleService=new RoleService();
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
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
        [HttpGet]
        public bool IsRegistered(string email)
        {
            return service.IsExist(email);
        }
    }
}
