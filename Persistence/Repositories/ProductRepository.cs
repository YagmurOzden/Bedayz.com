using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Repositories;
using bedayzAPI.Persistence.Contexts;

namespace bedayzAPI.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product>> ListAsync()//Product Category ilişkisi için, 1 e n ilişkide n olan bu kodu kullanmalı, n yani products.
        {
            return await _context.Products.Include(p => p.Category)
                                          .ToListAsync();
        }
        public async Task AddAsync(Product product)//Ekle
        {
            await _context.Products.AddAsync(product);
        }
        public async Task<Product> FindByIdAsync(int id)//Bul
        {
            return await _context.Products.FindAsync(id);
        }
        public void Update(Product product)//Güncelle
        {
            _context.Products.Update(product);
        }
        public void Remove(Product product)//Kaldır
        {
            _context.Products.Remove(product);
        }
    }
}
