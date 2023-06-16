using CommonLayer;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager manager;
        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        [Authorize(Roles ="User")]
        public ActionResult GetCart()
        {
            try
            {
                var UserId = Convert.ToInt64(User.FindFirst("Id").Value);
                var Check = manager.GetItems(UserId);
                if (Check != null)
                {
                    return Ok(new ResponseModel <IEnumerable<CartEntity>> { Data = Check, Status = true, Message = "All item in cart are fetched" });
                }
                return BadRequest(new ResponseModel<IEnumerable<CartEntity>> { Data = Check, Status = false, Message = "unable to fetch" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "User")]

        public ActionResult AddCartItem(AddCartItemModel model)
        {
            try
            {
                var UserId = Convert.ToInt64(User.FindFirst("Id").Value);
                var Check = manager.AddItemToCart(model,UserId);
                if (Check != null)
                {
                    return Ok(new ResponseModel<CartEntity> { Data = Check, Status = true, Message = "Item added successfully" });
                }
                return BadRequest(new ResponseModel<CartEntity> { Data = Check, Status = false, Message = "unable to add Item" });
            }
            
            catch (System.Exception)
            {

                throw;
            }
        }
        
        [HttpPut("ItemId")]
        [Authorize(Roles = "User")]
        public ActionResult UpdateCartQuantity(long ItemId,int quantity)
        {
            try
            {
                var Check = manager.UpdateQuantity(ItemId, quantity);
                if (Check != null)
                {
                    return Ok(new ResponseModel<CartEntity> { Data = Check, Status = true, Message = "Item quantity updated" });
                }
                return BadRequest(new ResponseModel<CartEntity> { Data = Check, Status = false, Message = "unable to update quantity" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        [HttpDelete("BookId")]
        [Authorize(Roles = "User")]
        public ActionResult DeleteItem(int BookId)
        {
            try
            {
                var Check = manager.DeleteItem(BookId);
                if (Check ==true)
                {
                    return Ok(new ResponseModel<Boolean> { Data = Check, Status = true, Message = "Item removed successfully" });
                }
                return BadRequest(new ResponseModel<Boolean> { Data = Check, Status = false, Message = "unable to remove item" });
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

    
}
