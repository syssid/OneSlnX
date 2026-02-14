using Application.Features.Product.Command;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Domain.Entities.Product>();
            CreateMap<UpdateProductCommand, Domain.Entities.Product>()
                .ForMember(destination => destination.Description,
                           source => source.MapFrom(src => src.Remarks));
        }
    }
}
