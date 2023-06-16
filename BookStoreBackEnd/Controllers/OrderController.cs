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
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager manager;
        public OrderController(IOrderManager manager)
        {
            this.manager = manager;
        }
        [Authorize(Roles ="User")]
        [HttpPost]
        public ActionResult AddOrder(List<int> bookIds)
        {
            try
            {
                var UserId = Convert.ToInt64(User.FindFirst("Id").Value);
                var Check = manager.AddOrder(bookIds, UserId);
                if (Check != null)
                {
                    return Ok(new ResponseModel<OrderEntity> { Data = Check, Status = true ,Message="Order Placed Successfully"});
                }
                return BadRequest(new ResponseModel<OrderEntity> { Data = Check, Status = true, Message = "Unable to place Order" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
