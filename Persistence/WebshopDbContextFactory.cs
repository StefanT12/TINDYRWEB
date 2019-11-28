using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class WebshopDbContextFactory : DesignTimeDbContextFactoryBase<WebshopDbContext>
    {
        protected override WebshopDbContext CreateNewInstance(DbContextOptions<WebshopDbContext> options)
        {
            return new WebshopDbContext(options);
        }
    }

}
