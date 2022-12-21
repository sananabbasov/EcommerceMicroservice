using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound = "User not found.";
        public static string UserExists = "User already exists.";
        public static string LoginError = "Email or password not correct.";
        public static string RegisterSuccessfully = "You have successfully registered. Check your email.";
        public static string SuccessfullyLike = "Like is successfully added.";
    }
}
