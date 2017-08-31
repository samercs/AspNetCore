using AspNetCore.Data;
using AspNetCore.Web.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Web.Features.Shared
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