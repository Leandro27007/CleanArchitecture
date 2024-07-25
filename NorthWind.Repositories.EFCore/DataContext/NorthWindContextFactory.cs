using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.DataContext
{
    class NorthWindContextFactory :
       IDesignTimeDbContextFactory<NorthWindContext>
    {
        //Este factory funciona para crear migraciones exclusivas para el DataContext
        public NorthWindContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<NorthWindContext>();

            optionsBuilder.UseSqlServer("Server=.;database=NorthWindDB; TrustServerCertificate=True; Integrated Security=true"); 
            return new NorthWindContext(optionsBuilder.Options);
        }
    }
}
