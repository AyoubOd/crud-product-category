using tp11.Models;
using tp11.Repositories.Interfaces;

namespace tp11.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<IEnumerable<Product>> All()
    {
        throw new NotImplementedException();
    }

    public Product? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entity)
    {
        throw new NotImplementedException();
    }
}