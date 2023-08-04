using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<ShortLink> ShortLinks { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public User()
        {
            ShortLinks = new List<ShortLink>();
            RowInsertTime = DateTime.Now;
            RowUpdateTime = DateTime.Now;
        }
    }
}
