using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.DTO;

namespace URL_Shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private IRoleService service= new RoleService();
        private readonly IMapper _mapper;
        public RoleController(ILogger<RoleController> logger,IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public List<RoleDTO> Get()
        {
            return _mapper.Map<List<RoleDTO>>(service.GetAllRoles());
        }
    }
}
