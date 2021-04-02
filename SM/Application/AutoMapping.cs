using Application.Features.Masters.Commands.CreateMaster;
using Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateMasterCommand, Master>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
