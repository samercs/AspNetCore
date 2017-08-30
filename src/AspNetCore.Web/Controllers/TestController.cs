using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Web.Controllers
{
    public class TestController : AppBaseController
    {
        public TestController(IAppService appServices) : base(appServices)
        {
        }
        public IActionResult Index()
        {
            var siteTitle = AppServices.AppSettings.SiteTitle;
            return View("Index", siteTitle);
        }

        
    }
}