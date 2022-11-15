using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_App.Models
{
    public class ResetPassword
    {
        public string emailId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
