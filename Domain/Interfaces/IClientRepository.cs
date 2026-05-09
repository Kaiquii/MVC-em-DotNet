using Cadastro.Domain.Entities;

namespace Cadastro.Domain.Interfaces
{
    public interface IClientRepository
    {
        Client Get(int id);
        IEnumerable<Client> GetAll();
        void Insert(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
