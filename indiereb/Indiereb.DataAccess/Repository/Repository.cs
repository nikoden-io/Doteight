using System.Linq.Expressions;
using Indiereb.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Indiereb.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext db)
    {
        _dbSet = db.Set<T>();
        // For ex: _db.Categories == dbSet
    }


    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = _dbSet;
        return query.ToList();
    }

    public T GetOne(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        _dbSet.RemoveRange(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}