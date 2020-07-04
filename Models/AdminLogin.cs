using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApproval.Models
{
    public class AdminLogin
    {
        public string username { get; set; }

        public int uid { get; set; }
        public int status { get; set; }

        public List<userSignup> listOfUnApprovedUsers { get; set; }
    }
}
