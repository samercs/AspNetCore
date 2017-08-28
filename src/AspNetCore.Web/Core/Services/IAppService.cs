using AspNetCore.Data;

namespace AspNetCore.Web.Core.Services
{
    public interface IAppService
    {
        IDataContextFactory DataContextFactory { get; set; }
    }
}