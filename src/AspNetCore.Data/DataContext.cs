using System;
using System.Linq;
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
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var addedEntities = ChangeTracker.Entries()
                    .Where(i => i.State == EntityState.Added)
                    .Where(i => i.Entity is EntityBase);

                foreach (var entity in addedEntities)
                {
                    ((EntityBase)entity.Entity).CreatedUtc = DateTime.UtcNow;
                }

                var modifiedEntities = ChangeTracker.Entries()
                    .Where(i => i.State == EntityState.Modified)
                    .Where(i => i.Entity is EntityBase);

                foreach (var entity in modifiedEntities)
                {
                    ((EntityBase)entity.Entity).ModifiedUtc = DateTime.UtcNow;
                }
                return await base.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetModified(object entity)
        {
            base.Entry(entity).State = EntityState.Modified;
        }
    }
}