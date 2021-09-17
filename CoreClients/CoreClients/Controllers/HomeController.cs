using CoreClients.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreClients.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<SignalRServer> _hubContext;
        private readonly IProductsRepository _prodRepo;

        public HomeController(IHubContext<SignalRServer> hubContext, IProductsRepository prodRepo)
        {
            _hubContext = hubContext;
            _prodRepo = prodRepo;
        }

        public IActionResult Index()
        {
            var products = _prodRepo.GeAll("SELECT * FROM Products").ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
