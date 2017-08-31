using AspNetCore.Data;
using AspNetCore.Web.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        protected JsonResult KendoJson(object data)
        {
            return Json(data, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            });
        }
    }
}