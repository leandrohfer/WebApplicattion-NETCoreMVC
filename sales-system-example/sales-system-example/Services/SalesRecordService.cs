using Microsoft.EntityFrameworkCore;
using sales_system_example.Data;
using sales_system_example.Models;
using System.Collections.Generic;

namespace sales_system_example.Services
{
    public class SalesRecordService
    {
        private readonly sales_system_exampleContext _context;

        public SalesRecordService(sales_system_exampleContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
            .ToListAsync();
        }

        public async Task<IQueryable<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            
            /*
            var teste = result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToList();

            Console.WriteLine("\n\n\n\n\n");
            //Console.WriteLine(teste);
            Console.WriteLine("\n\n\n\n\n");
            */

            try
            {
                IQueryable<IGrouping<Department, SalesRecord>> prodQuery =
                    (IQueryable<IGrouping<Department, SalesRecord>>)(from prod in _context.SalesRecord
                    group prod by prod.Seller.Department into grouping
                    select grouping);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            foreach (IGrouping<Department, SalesRecord> grp in prodQuery)
            {
                Console.WriteLine("\nCategoryID Key = {0}:", grp.Key.Name);
                foreach (SalesRecord listing in grp)
                {
                    Console.WriteLine("\t{0}", listing.Seller.Name);
                }
            }*/

            return (IQueryable<IGrouping<Department, SalesRecord>>)result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                ;
        }
    }
}
