using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedPartsDepotAPI.Models
{
    public class User
    {
        public string userFirst { get; set; }
        public string userLast { get; set; }
        public string joinDate { get; set; }
        public string email { get; set; }

        //for development only! TODO : dont use string passsword
        public string password { get; set; }
    }
}