using System.Collections.Generic;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class ShoppingCartsDetailsProfile : Profile
    {
        public ShoppingCartsDetailsProfile()
        {
            CreateMap<ShoppingCartDetailCreate, ShoppingCartDetail>();
            CreateMap<ShoppingCartDetailRequestDto,  ShoppingCartDetail>();
            
            CreateMap<ShoppingCartDetailPatchDto, ShoppingCartDetail>();
            CreateMap<ShoppingCartDetail, ShoppingCartDetailPatchDto>();

            CreateMap<ShoppingCartDetail, ShoppingCartDetailReadDto>();
            
        }
    }
}