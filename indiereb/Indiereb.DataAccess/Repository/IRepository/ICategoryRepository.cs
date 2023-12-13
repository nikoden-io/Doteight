using Indiereb.Models.Models;

namespace Indiereb.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
}