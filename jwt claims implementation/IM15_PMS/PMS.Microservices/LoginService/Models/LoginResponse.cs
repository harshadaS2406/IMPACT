using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public int RoleID { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; }
    }
}
