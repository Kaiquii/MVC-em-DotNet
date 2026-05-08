using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductViewModelService(
            IProductRepository productRepository,
            IClientRepository clientRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public ProductViewModel Get(int id)
        {
            var entity = _productRepository.Get(id);
            if (entity == null)
                return null;

            var viewModel = _mapper.Map<ProductViewModel>(entity);
            CompleteNames(viewModel);
            return viewModel;
        }

        public ProductViewModel GetFormData()
        {
            return LoadOptions(new ProductViewModel { Active = true });
        }

        public ProductViewModel GetFormData(int id)
        {
            var viewModel = Get(id);
            return viewModel == null ? null : LoadOptions(viewModel);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var list = _productRepository.GetAll();
            if (list == null)
                return new ProductViewModel[] { };

            var viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(list).ToList();
            foreach (var viewModel in viewModels)
                CompleteNames(viewModel);

            return viewModels;
        }

        public void Insert(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);
            entity.Id = 0;
            _productRepository.Insert(entity);
        }

        public ProductViewModel LoadOptions(ProductViewModel viewModel)
        {
            viewModel.Clients = _clientRepository.GetAll()
                .OrderBy(client => client.Name)
                .Select(client => new SelectListItem
                {
                    Value = client.Id.ToString(),
                    Text = $"{client.Name} {client.LastName} - {client.Email}"
                });

            viewModel.Categories = _categoryRepository.GetAll()
                .OrderBy(category => category.Name)
                .Select(category => new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });

            return viewModel;
        }

        public void Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);
            _productRepository.Update(entity);
        }

        private void CompleteNames(ProductViewModel viewModel)
        {
            var client = _clientRepository.Get(viewModel.IdClient);
            viewModel.ClientName = client == null ? string.Empty : $"{client.Name} {client.LastName}";

            var category = _categoryRepository.Get(viewModel.IdCategory);
            viewModel.CategoryName = category == null ? string.Empty : category.Name;
        }
    }
}
