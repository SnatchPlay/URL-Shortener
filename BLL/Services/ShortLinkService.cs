using BLL.Interfaces;
using DAL.EF;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ShortLinkService : IShortLinkInterface
    {
        private static Random random = new Random();
        private ApplicationContext _context=new ApplicationContext();

        public void AddShortLink(ShortLink shortLink)
        {
            
            _context.ShortLinks.Add(shortLink);
        }

        public void CreateShortLink(string url, User creatorUser, string token)
        {
            var sh=_context.ShortLinks.ToList().Exists(x=>x.Url==url);
            if (sh) { throw new Exception("URL already shortened."); }
            else
            {
                _context.ShortLinks.Add(new ShortLink { Url = url , CreatorUserId=creatorUser.Id, Token=token});
                _context.SaveChanges();
            }
        }

        public void DeleteShortLink(int id)
        {
            ShortLink? shortLink = _context.ShortLinks.Find(id);
            if (shortLink != null)
            {
                _context.ShortLinks.Remove(shortLink);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No short link with id.");
            }
        }

        public List<ShortLink> GetAllShortLinks()
        {
            return _context.ShortLinks.ToList();
        }

        public ShortLink GetShortLinkById(int id)
        {
            ShortLink? shortLink = _context.ShortLinks.Find(id);
            if (shortLink != null)
            {
                return shortLink;
            }
            else
            {
                throw new Exception("No short link with id.");
            }
        }

        public ShortLink GetShortLinkByToken(string token)
        {
            try
            {
                ShortLink? shortLink = _context.ShortLinks.First(x => x.Token == token);
                if (shortLink != null)
                    return shortLink;
                else
                    throw new Exception("No url with this token");
            }
            catch { throw new Exception(); }//no shortlinks in database
        }

        public string TokenGenerator()
        {
            int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
