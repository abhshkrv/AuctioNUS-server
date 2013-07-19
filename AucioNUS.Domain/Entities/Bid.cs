using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Entities
{
    public class Bid
    {
        public int BidID { get; set; }
        public int DealID { get; set; }
        public int UserID { get; set; }
        public int points { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
