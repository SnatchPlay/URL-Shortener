using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace URL_Shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortLinkController : ControllerBase
    {
        private readonly ILogger<ShortLinkController> _logger;
        private IShortLinkInterface service = new ShortLinkService();
        private IUserService userService = new UserService(); 

        public ShortLinkController(ILogger<ShortLinkController> logger)
        {
            _logger = logger;

        }
        [HttpGet,Route("/shortlink/{id}")]
        public ShortLink GetShortLinkById(int id)
        {
            return service.GetShortLinkById(id);
        }
        [HttpGet]
        public List<ShortLink> GetShortLinks()
        {
            return service.GetAllShortLinks();
        }
        [HttpGet,Route("/{token}")]
        public IActionResult TokenRedirect( string token)
        {
            return Redirect(service.GetShortLinkByToken(token).Url);
        }
        [HttpPost]
        public void PostURL(string url) 
        {
            if (!url.Contains("http"))
            {
                url = "http://" + url;
            }
            
            
            service.CreateShortLink(url, userService.GetAllUsers()[0], service.TokenGenerator());
        }
    }
}
