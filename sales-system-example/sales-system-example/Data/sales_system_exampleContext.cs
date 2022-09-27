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

        public DbSet<sales_system_example.Models.Department> Department { get; set; } = default!;
    }
}
