using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Data;
using AspNetCore.Web.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Web.Controllers
{
    public class AppBaseController : Controller
    {
        public readonly IAppService AppServices;
        protected readonly IDataContextFactory DataContextFactory;
        protected AppBaseController(IAppService appServices)
        {
            AppServices = appServices;
            DataContextFactory = appServices.DataContextFactory;
        }
    }
}