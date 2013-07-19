using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Entities
{
    public class Setting
    {
        public int SettingID { get; set; }
        public int UserID { get; set; }
        public byte settingByte { get; set; }
    }
}
