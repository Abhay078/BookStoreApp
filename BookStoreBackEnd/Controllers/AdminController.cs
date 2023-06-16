using CommonLayer;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminManager manager;
        public AdminController(IAdminManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult AdminRegister(UserRegModel model)
        {
            try
            {
                var CheckReg = manager.AdminRegister(model);
                if (CheckReg != null)
                {
                    return Ok(new ResponseModel<AdminEntity> { Status = true, Message = "Register Successfull", Data = CheckReg });
                }
                else
                {
                    return BadRequest(new ResponseModel<AdminEntity> { Status = false, Message = "Register unsuccessful", Data = CheckReg });
                }

            }
            catch (Exception)
            {
                throw;

            }

        }
        [HttpPost("Login")]
        public ActionResult AdminLogin(LoginModel model)
        {
            try
            {

                var checkLogin = manager.Login(model);
                if (checkLogin != null)
                {
                    var tokenString = manager.Generate(checkLogin.Email, checkLogin.AdminId, "Admin");
                    return Ok(new ResponseModel<string> { Status = true, Message = "Login Successful", Data = tokenString });

                }
                else
                {
                    return BadRequest(new ResponseModel<string> { Status = false, Message = "Login Unsuccessfull" });
                }

            }
            catch (Exception ex)
            {
                throw;

            }


        }
    }
}
