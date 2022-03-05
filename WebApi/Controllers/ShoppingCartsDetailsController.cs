using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsDetailsController : ControllerBase
    {
        private readonly IShoppingCartsDetailRepository _shoppingCartsDetailRepository;
        private readonly IMapper _mapper;
        
        public ShoppingCartsDetailsController(IShoppingCartsDetailRepository shoppingCartsDetailRepository, IMapper mapper)
        {
            _shoppingCartsDetailRepository = shoppingCartsDetailRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public ActionResult<ShoppingCartDetail> AddItemToShoppintCart(ShoppingCartDetailCreate shoppingCartDetailCreate)
        {
            var shoppingCartDetail = _mapper.Map<ShoppingCartDetail>(shoppingCartDetailCreate);  
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(); 
            shoppingCartDetail.Total = shoppingCartDetail.Quantity * shoppingCartDetail.Price;

            // Datos de Auditoria
            shoppingCartDetail.IpAddress = remoteIpAddress;
            shoppingCartDetail.CreatedOn = System.DateTime.Now;


            _shoppingCartsDetailRepository.CreateDetail(shoppingCartDetail);
            _shoppingCartsDetailRepository.SaveChanges();
            return Ok(shoppingCartDetail);
        }

        [HttpPatch("{id}")]
        public ActionResult<ShoppingCartDetail> UpdateItemShoppingCart(int id, JsonPatchDocument<ShoppingCartDetailPatchDto> patchDoc)
        {
            var itemModelFromRepo = _shoppingCartsDetailRepository.GetShoppingCartDetailById(id);
            

            if(itemModelFromRepo == null)
            {
                return NotFound();
            }   

            var itemToPatch =  _mapper.Map<ShoppingCartDetailPatchDto>(itemModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);
            if(!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemToPatch, itemModelFromRepo);

            itemModelFromRepo.Total = itemModelFromRepo.Quantity * itemModelFromRepo.Price;

            // Datos de Auditoria
            itemModelFromRepo.UpdatedOn = System.DateTime.Now;

            _shoppingCartsDetailRepository.UpdateDetail(itemModelFromRepo);
            
            _shoppingCartsDetailRepository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult RemoveItemShoppingCart(int id)
        {
            var findItem = _shoppingCartsDetailRepository.GetShoppingCartDetailById(id);
            if(findItem == null) {
                return NotFound();
            }
            _shoppingCartsDetailRepository.DeleteItem(id);
            _shoppingCartsDetailRepository.SaveChanges();
            return NoContent();
        }

        [HttpGet("Details/{shoppingCartId}")]
        public ActionResult GetItemsByShoppingCartId(int shoppingCartId) 
        {
            var listShoppingCartDetail = _shoppingCartsDetailRepository.GetShoppingItemsByShoppingCartId(shoppingCartId);
            return Ok(_mapper.Map<List<ShoppingCartDetailReadDto>>(listShoppingCartDetail));
        }
    }
}