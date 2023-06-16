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
    public class BookController : ControllerBase
    {
        private readonly IBookManager manager;
        public BookController(IBookManager manager)
        {
            this.manager = manager;

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddBook(AddBookModel model)
        {
            try
            {
                var Check = manager.AddBook(model);
                if (Check != null)
                {
                    return Ok(new ResponseModel<BookEntity> { Data = Check, Status = true, Message = "Book Added Successfully" });
                }
                return BadRequest(new ResponseModel<BookEntity> { Message = "Unable to add Book", Status = false, Data = Check });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                var Check = manager.DeleteBook(id);
                if (Check == true)
                {
                    return Ok(new ResponseModel<Boolean> { Data = Check, Status = true, Message = "Book Deleted Successfully" });
                }
                return BadRequest(new ResponseModel<Boolean> { Message = "Unable to Delete Book", Data = Check, Status = true });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult UpdateBook(AddBookModel model,int id)
        {
            try
            {
                var Check = manager.UpdateBook(model, id);
                if (Check != null)
                {
                    return Ok(new ResponseModel<BookEntity> { Data = Check, Status = true,Message="Updation of Book is successful" });
                }
                return BadRequest(new ResponseModel<BookEntity> { Data = Check, Status = false, Message = "Unable to update book" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize(Roles ="User")]
        [HttpGet]
        public ActionResult GetBook()
        {
            try
            {
                var Check = manager.GetBooks();
                if(Check!=null)
                {
                    return Ok(new ResponseModel<IEnumerable<BookEntity>> { Data = Check, Status = true, Message = "Get all book fetched" });
                }
                return BadRequest(new ResponseModel<IEnumerable<BookEntity>> { Data = Check, Status = false, Message = "Unable fetch all book" });


            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("Bookid")]
        public ActionResult GetBook(int Bookid)
        {
            try
            {
                var Check = manager.GetBookById(Bookid);
                if (Check != null)
                {
                    return Ok(new ResponseModel<BookEntity> { Data = Check, Status = true, Message = "Get book fetched" });
                }
                return BadRequest(new ResponseModel<BookEntity> { Data = Check, Status = false, Message = "Unable fetch book" });


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
