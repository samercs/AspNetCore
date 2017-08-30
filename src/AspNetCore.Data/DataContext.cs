using System.Threading.Tasks;
using AspNetCore.Entity;
using AspNetCore.Entity.Idintity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data
{
    public class DataContext: IdentityDbContext<User, MyRole, int> ,IDataContext
    {
        public DataContext(DbContextOptions options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed. 
            // For example, you can rename the ASP.NET Identity table names and more. 
            // Add your customizations after calling base.OnModelCreating(builder); 
        }

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