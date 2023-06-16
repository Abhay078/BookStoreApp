using CommonLayer;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;
using System;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        public ActionResult UserRegister(UserRegModel model)
        {
            try
            {
                var CheckReg = manager.UserRegister(model);
                if (CheckReg != null)
                {
                    return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register Successfull", Data = CheckReg });
                }
                else
                {
                    return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Register unsuccessfull", Data = CheckReg });
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }
        [HttpPost("Login")]
        public ActionResult UserLogin(LoginModel model)
        {
            try
            {

                var checkLogin = manager.Login(model);
                if (checkLogin != null)
                {
                    var tokenString = manager.Generate(checkLogin.Email, checkLogin.UserId,"User");
                    return Ok(new ResponseModel<string> { Status = true, Message = "Login Successful", Data = tokenString });

                }
                else
                {
                    return BadRequest(new ResponseModel<string> { Status = false, Message = "Login Unsuccessful" });
                }

            }
            catch (Exception ex)
            {
                throw;

            }


        }
        [Authorize(Roles ="User")]
        [HttpPost("Address")]
        
        public ActionResult AddAddress(AddAddressModel model)
        {
            try
            {
                var UserId = Convert.ToInt64(User.FindFirst("Id").Value);
                var Check = manager.AddAddress(model,UserId);
                if (Check != null)
                {
                    return Ok(new ResponseModel<AddressEntity> { Status = true, Data = Check, Message = "Address is added successfully" });
                }
                return BadRequest(new ResponseModel<AddressEntity> { Status = false, Data = Check, Message = "unable to add address" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize(Roles = "User")]
        [HttpPut("AddressId")]
        public ActionResult UpdateAddress(AddAddressModel model, long AddressId)
        {
            var Check=manager.UpdateAddress(model, AddressId);
            if (Check != null)
            {
                return Ok(new ResponseModel<AddressEntity> { Status = true, Data = Check, Message = "Address is updated successfully" });
            }
            return BadRequest(new ResponseModel<AddressEntity> { Status = false, Data = Check, Message = "Unable to update address" });
        }

        [Authorize(Roles = "User")]
        [HttpGet()]
        public ActionResult GetAddress()
        {
            var UserId = Convert.ToInt64(User.FindFirst("Id").Value);
            var Check = manager.GetAddress(UserId);
            if (Check != null)
            {
                return Ok(new ResponseModel<AddressEntity> { Status = true, Data = Check, Message = "Address is fetched successfully" });
            }
            return BadRequest(new ResponseModel<AddressEntity> { Status = false, Data = Check, Message = "Unable to fetch address" });
        }

    }

}
