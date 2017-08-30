using System;
using System.Threading.Tasks;

namespace AspNetCore.Data
{
    public interface IDataContext: IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void SetModified(object entity);
    }
}