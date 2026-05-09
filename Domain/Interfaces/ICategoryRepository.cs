using Cadastro.Domain.Entities;

namespace Cadastro.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
    }
}
