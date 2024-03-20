namespace tp11.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; init; }
    ICategoryRepository Categories { get; init; }

    Task<bool> CompleteAsync();
}