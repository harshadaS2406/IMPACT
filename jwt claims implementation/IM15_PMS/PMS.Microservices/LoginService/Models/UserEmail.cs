using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class UserEmail
    {
        public List<string> ToEmail { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
