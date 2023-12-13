using System.Linq.Expressions;

namespace Indiereb.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    // T - Category
    void Add(T entity);
    IEnumerable<T> GetAll();
    T GetOne(Expression<Func<T, bool>> filter);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
    void Update(T entity);
}