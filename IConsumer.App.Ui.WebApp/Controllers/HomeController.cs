using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IConsumer.App.Ui.WebApp.Models;
using IConsumer.App.Application.Interfaces;
using IConsumer.App.Domain.Entities;

namespace IConsumer.App.Ui.WebApp.Controllers
{
    public class HomeController : CustomBaseController
    {
        public HomeController(IAppStoreService sessionApp, ILogger<HomeController> logger) : base(sessionApp, logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            var dto = await _sessionApp.GetOpenedOrders();
            return View("~/Views/Home/Index.cshtml", dto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ReceiveOrder(Guid id)
        {
            await _sessionApp.UpdateOrderStatus(id, OrderStatus.Received);
            return await Index();
        }

        public async Task<IActionResult> DeliverOrder(Guid id)
        {
            await _sessionApp.UpdateOrderStatus(id, OrderStatus.Delivered);
            return await Index();
        }
    }
}
