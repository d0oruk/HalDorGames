using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // Navigational Property (Many to Many)
        public int GameId { get; set; }
        public Game Game { get; set; } // Navigational Property (Many to Many)
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
