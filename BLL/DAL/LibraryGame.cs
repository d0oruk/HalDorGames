using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class LibraryGame
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; } // Navigational Property (Many to Many)
        public int GameId { get; set; }
        public Game Game { get; set; } // Navigational Property (Many to Many)

    }
}
