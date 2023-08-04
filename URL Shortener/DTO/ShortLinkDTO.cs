using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.DTO
{
    public class ShortLinkDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public int CreatorUserId { get; set; }
        public UserDTO CreatorUser { get; set; }
        public DateTime RowInsertTime { get; set; }
        public ShortLinkDTO() 
        {
            RowInsertTime = DateTime.Now;
        }
    }
}
