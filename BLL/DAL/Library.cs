using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Library
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Required foreign key property
        public User User { get; set; } // Navigational Property (One to One)
        public List<LibraryGame> LibraryGames { get; set; } = new List<LibraryGame>(); // Navigational Property (One Side)

    }
}
