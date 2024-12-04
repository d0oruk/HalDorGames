// Merhaba, ben Halil.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(70)]
        public string UserName { get; set; }
        [Required, StringLength(70)]
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool? IsMale { get; set; }  // A user can be male, female, or do not want to specify it
        public DateTime BirthDate { get; set; } // Some games require age verification
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } //Navigational Property (Many Side)

        public List<Order> Orders { get; set; } = new List<Order>(); //Navigational Property (One Side)

        public Library Library { get; set; } // Reference navigation to dependent, Library

    }
}
