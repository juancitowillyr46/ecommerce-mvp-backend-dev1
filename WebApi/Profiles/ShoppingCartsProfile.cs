using System.Collections.Generic;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos.ShoppingCarts;

namespace WebApi.Profiles
{
    public class ShoppingCartsProfile : Profile
    {
        public ShoppingCartsProfile()
        {
            CreateMap<ShoppingCartCreateDto, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartCreateDto>();
            CreateMap<ShoppingCart, ShoppingCartReadDto>();
        }
    }
}