using AspNetCore.Data;
using AspNetCore.Web.Core.Configration;

namespace AspNetCore.Web.Core.Services
{
    public interface IAppService
    {
        IDataContextFactory DataContextFactory { get; set; }
        AppSettings AppSettings { get; set; }
    }
}