using System;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data
{
    public class DataContextFactory: IDataContextFactory
    {
        private readonly DbContextOptions _options;
        public DataContextFactory(string connectionString)
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public IDataContext GetContext()
        {
            return new DataContext(_options);
        }
    }
}