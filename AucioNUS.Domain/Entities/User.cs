using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string matricNo { get; set; }
        public string email { get; set; }
        public string phoneNo { get; set; }
        public bool phoneNumberVisibility { get; set; }
        public string deviceID { get; set; }
    }
}
