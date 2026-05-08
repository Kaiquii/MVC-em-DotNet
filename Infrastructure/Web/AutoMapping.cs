using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Infrastructure.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.ClientName, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryName, opt => opt.Ignore())
                .ForMember(dest => dest.Clients, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Client, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
