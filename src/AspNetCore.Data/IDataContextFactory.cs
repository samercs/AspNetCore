namespace AspNetCore.Data
{
    public interface IDataContextFactory
    {
        IDataContext GetContext();
    }
}