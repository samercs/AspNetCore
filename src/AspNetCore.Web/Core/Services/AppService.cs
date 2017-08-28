using AspNetCore.Data;

namespace AspNetCore.Web.Core.Services
{
    public class AppService: IAppService
    {
        public IDataContextFactory DataContextFactory { get; set; }
        public AppService(IDataContextFactory dataContextFactory)
        {
            DataContextFactory = dataContextFactory;
        }
    }
}