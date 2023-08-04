using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.DTO;

namespace URL_Shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortLinkController : ControllerBase
    {
        private readonly ILogger<ShortLinkController> _logger;
        private IShortLinkInterface service = new ShortLinkService();
        private IUserService userService = new UserService(); 
        private readonly IMapper _mapper;
        public ShortLinkController(ILogger<ShortLinkController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public List<ShortLinkDTO> GetShortLinks()
        {
            return _mapper.Map<List<ShortLinkDTO>>(service.GetAllShortLinks());
        }
        [HttpGet, Route("/shortlink/id={id}")]
        public ShortLinkDTO GetShortLink(int id)
        {
            return _mapper.Map<ShortLinkDTO>(service.GetShortLinkById(id));
        }
        [HttpGet,Route("/shortlink/{token}")]
        public IActionResult TokenRedirect(string token)
        {
            int index = token.IndexOf("shortlink");
            string cleanPath = (index < 0)
                ? token
                : token.Remove(index, "shortlink".Length);
            return Redirect(service.GetShortLinkByToken(cleanPath).Url);
        }
        [HttpPost]
        public void PostURL(string url) 
        {
            if (!url.Contains("https"))
            {
                url = "https://" + url;
            }
            service.CreateShortLink(url, userService.GetAllUsers()[0], service.TokenGenerator());
        }
    }
}
