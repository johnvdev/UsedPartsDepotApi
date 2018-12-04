using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedPartsDepotAPI.Models
{
    public class Part
    {
      
        public string PartsID;
        public string UserID;
        public string Title;
        public string Desc;
        public double Price;
        public string Location;
        public string[] Vehicle;
        public string Category;
    }
}