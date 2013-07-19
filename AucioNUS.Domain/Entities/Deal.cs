using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Entities
{
    public class Deal
    {
        public int DealID { get; set; }
        public int UserID { get; set; }
        public bool type { get; set; }
        public string author { get; set; }
        public string bookName { get; set; }
        public string ISBN { get; set; }
        public DateTime closingDate { get; set; }
        public float price { get; set; }
        public string imgUrl { get; set; }
    }
}
