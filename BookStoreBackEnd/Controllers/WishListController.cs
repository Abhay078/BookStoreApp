using CommonLayer;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListManager manager;
        public WishListController(IWishListManager manager)
        {
            this.manager = manager;
        }
        [Authorize(Roles ="User")]
        [HttpPost("BookId")]
        public ActionResult Addtem(int BookId)
        {
            try
            {
                var UserId = Convert.ToInt32(User.FindFirst("Id").Value);
                var Check = manager.AddItem(BookId,UserId);
                if(Check!= null)
                {
                    return Ok(new ResponseModel<WishListEntity> { Data = Check, Status = true ,Message="WishListed Successsfully"}) ;
                }
                return BadRequest(new ResponseModel<WishListEntity> { Data = Check, Status = false, Message = "Unable to wishlist" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize(Roles ="User")]
        [HttpDelete("BookId")]
        public ActionResult DeleteItem(int BookId)
        {
            try
            {
                var Check = manager.DeleteItem(BookId);
                if (Check == true)
                {
                    return Ok(new ResponseModel<Boolean> { Data = Check, Status = true, Message = "Item Removed Successsfully" });
                }
                return BadRequest(new ResponseModel<Boolean> { Data = Check, Status = false, Message = "Unable to remove Item" });
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [Authorize(Roles ="User")]
        [HttpGet]
        public ActionResult GetItem()
        {
            try
            {
                var Check = manager.GetAll();
                if (Check!=null)
                {
                    return Ok(new ResponseModel<IEnumerable<WishListEntity>> { Data = Check, Status = true, Message = "All Item fetched" });
                }
                return BadRequest(new ResponseModel<IEnumerable<WishListEntity>> { Data = Check, Status = false, Message = "Unable to fetch all items" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
