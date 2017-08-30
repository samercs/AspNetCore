using AspNetCore.Data;
using AspNetCore.Web.Core.Configration;
using Microsoft.Extensions.Options;

namespace AspNetCore.Web.Core.Services
{
    public class AppService: IAppService
    {
        public IDataContextFactory DataContextFactory { get; set; }
        public AppSettings AppSettings { get; set; }
        public AppService(IDataContextFactory dataContextFactory, IOptions<AppSettings> options)
        {
            DataContextFactory = dataContextFactory;
            AppSettings = options.Value;
        }
    }
}