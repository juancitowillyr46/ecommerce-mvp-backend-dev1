using System.Collections.Generic;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Dtos.ShoppingCartsItems;

namespace WebApi.Profiles
{
    public class ShoppingCartsDetailsProfile : Profile
    {
        public ShoppingCartsDetailsProfile()
        {
            CreateMap<ShoppingCartItemCreateDto, ShoppingCartItem>();
            CreateMap<ShoppingCartDetailRequestDto,  ShoppingCartItem>();
            
            CreateMap<ShoppingCartDetailPatchDto, ShoppingCartItem>();
            CreateMap<ShoppingCartItem, ShoppingCartDetailPatchDto>();

            CreateMap<ShoppingCartItem, ShoppingCartItemReadDto>();
            
        }
    }
}