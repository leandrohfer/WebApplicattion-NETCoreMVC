using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_system_example.Data;
using sales_system_example.Models;
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
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
