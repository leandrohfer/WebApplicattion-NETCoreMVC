using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sales_system_example.Models;

namespace sales_system_example.Data
{
    public class sales_system_exampleContext : DbContext
    {
        public sales_system_exampleContext (DbContextOptions<sales_system_exampleContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
