using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Entities
{
    public class Module
    {
        public int ModuleID { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string recommendedBookName { get; set; }
    }
}
