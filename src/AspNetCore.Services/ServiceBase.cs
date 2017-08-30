using AspNetCore.Data;

namespace AspNetCore.Services
{
    public class ServiceBase
    {
        private readonly IDataContextFactory _dataContextFactory;

        public ServiceBase(IDataContextFactory dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public IDataContext DataContext()
        {
            return _dataContextFactory.GetContext();
        }

    }
}