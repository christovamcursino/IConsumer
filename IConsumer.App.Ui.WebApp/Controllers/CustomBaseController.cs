using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConsumer.App.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace IConsumer.App.Ui.WebApp.Controllers
{
    [Authorize]
    public abstract class CustomBaseController : Controller
    {
        protected readonly IAppStoreService _sessionApp;
        private readonly ILogger<HomeController> _logger;

        protected CustomBaseController(IAppStoreService sessionApp, ILogger<HomeController> logger)
        {
            _sessionApp = sessionApp;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            _sessionApp.RegisterToken(HttpContext.GetTokenAsync("access_token"), User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        }
    }
}
