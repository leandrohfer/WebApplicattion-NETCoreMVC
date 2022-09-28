using Microsoft.EntityFrameworkCore;
using sales_system_example.Data;
using sales_system_example.Models;

namespace sales_system_example.Services
{
    public class DepartmentService
    {
        private readonly sales_system_exampleContext _context;

        public DepartmentService(sales_system_exampleContext context)
        {
            _context = context;
        }


        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
