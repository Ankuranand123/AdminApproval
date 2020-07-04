using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AdminApproval.Models
{
    public class userSignup
    {

        public int id { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string city { get; set; }

        public string  password { get; set; }

        public int isApproved { get; set; }
    }
}
