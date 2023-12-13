using indiereb.Data;
using Indiereb.DataAccess.Repository.IRepository;
using Indiereb.Models.Models;

namespace Indiereb.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    void IRepository<Category>.Update(Category entity)
    {
        _db.Categories.Update(entity);
    }
}