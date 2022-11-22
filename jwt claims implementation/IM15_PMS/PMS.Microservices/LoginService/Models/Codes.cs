using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Codes
    {
        public const int InvalidCredentials = 101;
        public const int IncorrectOldPassword = 102;
        public const int PasswordDidNotMatch = 103;
        public const int EmailIDNotFound = 104;
        public const int PasswordChangedSuccess = 105;
        public const int EmailSentResetPassword = 106;
        public const int PromptChangePassword = 107;
        public const int LoginSuccess = 108;
        public const int AccountLockout = 109;
    }
    public class Response
    {
        public int ResponseCode { get; set; }

        public object ResponseInfo { get; set; }
    }


    public class EmailCodes
    {
        public const int WelcomeEmail = 301;
        public const int WelcomeEmailCP = 302;
        public const int ResetPassword = 303;

    }


}
