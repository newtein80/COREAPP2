using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.DbContexts
{
    public class SpDbContextFactory : DesignTimeDbContextFactoryBase<SpDbContext>
    {
        protected override SpDbContext CreateNewInstance(DbContextOptions<SpDbContext> options)
        {
            return new SpDbContext(options);
        }
    }
}
