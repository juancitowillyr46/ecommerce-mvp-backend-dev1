using System.Collections.Generic;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class ShoppingCartsProfile : Profile
    {
        public ShoppingCartsProfile()
        {
            CreateMap<ShoppingCartCreateRequestDto, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartCreateResponseDto>();
        }
    }
}