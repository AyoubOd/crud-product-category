using Microsoft.EntityFrameworkCore;
using tp11.Data.Repositories.Interfaces;
using tp11.Models;

namespace tp11.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> All()
    {
        return await _context.Categories.ToListAsync();
    }

    public Category? GetById(Guid id)
    {
        return _context.Categories.Find(id);
    }

    public void Add(Category entity)
    {
        _context.Categories.Add(entity);
    }

    public void Update(Category entity)
    {
        _context.Categories.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Category entity)
    {
        _context.Categories.Remove(entity);
    }
}