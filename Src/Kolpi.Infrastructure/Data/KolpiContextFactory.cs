using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolpi.Infrastructure.Data
{
    internal class KolpiContextFactory : IDesignTimeDbContextFactory<KolpiDbContext>
    {
        public KolpiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KolpiDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KolpiServerContext-014917e0-fcbe-4c08-8874-ace3897c77b4;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new KolpiDbContext(optionsBuilder.Options);
        }
    }
}
