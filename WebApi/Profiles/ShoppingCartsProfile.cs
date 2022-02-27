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

            //CreateMap<ShoppingCart, ShoppingCartCreateRequestDto>();
            CreateMap<ShoppingCart, ShoppingCartCreateResponseDto>();
            //CreateMap<List<ShoppingCartDetailRequestDto>,  List<ShoppingCartDetail>>();
        }
    }
}