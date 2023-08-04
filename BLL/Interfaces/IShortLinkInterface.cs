using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IShortLinkInterface
    {
        public void CreateShortLink(string url, User user, string token);
        public void AddShortLink(ShortLink shortLink);
        public void DeleteShortLink(int id);
        public ShortLink GetShortLinkById(int id);
        public ShortLink GetShortLinkByToken(string token);
        public List<ShortLink> GetAllShortLinks();
        public string TokenGenerator();

    }
}
