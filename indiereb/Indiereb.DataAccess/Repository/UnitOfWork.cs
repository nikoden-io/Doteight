using indiereb.Data;
using Indiereb.DataAccess.Repository.IRepository;

namespace Indiereb.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(db);
    }

    public ICategoryRepository Category { get; }


    public void Save()
    {
        _db.SaveChanges();
    }
}