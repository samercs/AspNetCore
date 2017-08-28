using System.Threading.Tasks;
using AspNetCore.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetCore.Data
{
    public class DataContext: IdentityDbContext<User> ,IDataContext
    {
        public override int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SetModified(object entity)
        {
            throw new System.NotImplementedException();
        }
    }
}