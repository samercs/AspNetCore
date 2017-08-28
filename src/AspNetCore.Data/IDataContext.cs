using System.Threading.Tasks;

namespace AspNetCore.Data
{
    public interface IDataContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void SetModified(object entity);
    }
}