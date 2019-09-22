using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library;
using PizzaStore.WebUI.Models;

namespace PizzaStore.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public IStoreRepo Repo { get; }

        public HomeController(IStoreRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult Privacy()
        {
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
