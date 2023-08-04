

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public List<ShortLinkDTO> ShortLinks { get; set; }
        public UserDTO() 
        { 
            ShortLinks = new List<ShortLinkDTO>();
        }
    }
}
