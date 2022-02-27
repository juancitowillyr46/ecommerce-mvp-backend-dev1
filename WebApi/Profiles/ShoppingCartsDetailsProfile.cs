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
            CreateMap<ShoppingCartDetailRequestDto,  ShoppingCartDetail>();
        }
    }
}