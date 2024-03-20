using tp11.Data.Repositories.Interfaces;

namespace tp11.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository Products { get; init; }
    public ICategoryRepository Categories { get; init; }
    private readonly ApplicationDbContext _appContext;

    public UnitOfWork(ApplicationDbContext appContext)
    {
        _appContext = appContext;
        Products = new ProductRepository(_appContext);
        Categories = new CategoryRepository(_appContext);
    }

    public async Task<bool> CompleteAsync()
    {
        return await _appContext.SaveChangesAsync() > 0;
    }
}