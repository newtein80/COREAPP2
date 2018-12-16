using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.DbContexts
{
    public class EfDbContextFactory : DesignTimeDbContextFactoryBase<EfDbContext>
    {
        protected override EfDbContext CreateNewInstance(DbContextOptions<EfDbContext> options)
        {
            return new EfDbContext(options);
        }
    }
}