using tp11.Models;

namespace tp11.Data.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> All();
    T? GetById(Guid id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}