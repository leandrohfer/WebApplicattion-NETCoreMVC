using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_system_example.Data;
using sales_system_example.Models;
using sales_system_example.Services.Exceptions;
using System.Collections.Generic;

namespace sales_system_example.Services
{
    public class SellerService
    {
        private readonly sales_system_exampleContext _context;

        public SellerService(sales_system_exampleContext context)
        {
            _context = context;
        }


        // A função abaixo é do tipo Sync (não recomendado, devido a perda de otimização)
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
