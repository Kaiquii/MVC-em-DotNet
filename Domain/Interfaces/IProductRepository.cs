using Cadastro.Domain.Entities;

namespace Cadastro.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product Get(int id);
        IEnumerable<Product> GetAll();
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
