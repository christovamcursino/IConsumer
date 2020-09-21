using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IConsumer.App.Ui.WebApp.Helper
{
    public static class UserHelper
    {
        public static string ExtractEmail(ClaimsPrincipal user)
        {
            return user.FindFirst("name").Value;
        }
    }
}
