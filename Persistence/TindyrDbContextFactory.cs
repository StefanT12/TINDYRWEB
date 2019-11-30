using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class TindyrDbContextFactory : DesignTimeDbContextFactoryBase<TindyrDbContext>
    {
        protected override TindyrDbContext CreateNewInstance(DbContextOptions<TindyrDbContext> options)
        {
            return new TindyrDbContext(options);
        }
    }

}
