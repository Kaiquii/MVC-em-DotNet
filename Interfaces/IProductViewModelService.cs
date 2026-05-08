using Cadastro.ViewModels;
using System.Collections.Generic;

namespace Cadastro.Interfaces
{
    public interface IProductViewModelService
    {
        ProductViewModel Get(int id);
        ProductViewModel GetFormData();
        ProductViewModel GetFormData(int id);
        ProductViewModel LoadOptions(ProductViewModel viewModel);
        IEnumerable<ProductViewModel> GetAll();
        void Insert(ProductViewModel viewModel);
        void Update(ProductViewModel viewModel);
        void Delete(int id);
    }
}
