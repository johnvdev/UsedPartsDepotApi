using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedPartsDepotAPI.Models
{
    public class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string trim { get; set; }
        public string displacement { get; set; }
    }

}