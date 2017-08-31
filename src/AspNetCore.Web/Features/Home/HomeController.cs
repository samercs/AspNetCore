using System.Diagnostics;
using AspNetCore.Web.Core.Services;
using AspNetCore.Web.Features.Shared;
using AspNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Web.Features.Home
{
    public class HomeController : AppBaseController
    {
        public HomeController(IAppService appServices) : base(appServices)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
