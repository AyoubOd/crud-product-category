using Microsoft.EntityFrameworkCore;
using tp11.Data.Repositories.Interfaces;
using tp11.Models;

namespace tp11.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> All()
    {
        return await _context
            .Products
            .AsNoTracking()
            .ToListAsync();
    }

    public Product? GetById(Guid id)
    {
        return _context.Products.Find(id);
    }

    public void Add(Product entity)
    {
        _context.Products.Add(entity);
    }

    public void Update(Product entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Product entity)
    {
        _context.Products.Remove(entity);
    }
}