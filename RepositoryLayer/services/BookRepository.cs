using CommonLayer;
using RepositoryLayer.BookDbContext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.services
{
    public class BookRepository:IBookRepository
    {
        private readonly BookContext _context;
       
        public BookRepository(BookContext context) 
        {
            _context = context;
        }
        public BookEntity AddBook(AddBookModel model)
        {
            try
            {
                BookEntity book = new BookEntity();
                book.Title = model.Title;
                book.Description = model.Description;
                book.Author = model.Author;
                book.Quantity = model.Quantity;
                book.Price = model.Price;
                book.DiscountedPrice = model.DiscountedPrice;
                book.BookImage = model.BookImage;
                var Check = _context.Book.Add(book);
                _context.SaveChanges();
                if (Check != null)
                {
                    return book;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public Boolean DeleteBook(int bookId)
        {
            try
            {
                var Check = _context.Book.FirstOrDefault(x => x.BookId == bookId);
                if (Check != null)
                {
                    _context.Book.Remove(Check);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public BookEntity UpdateBook(AddBookModel model,int bookId)
        {
            try
            {
                var Check=_context.Book.FirstOrDefault(x=>x.BookId == bookId);
                if (Check != null)
                {
                    Check.Title=model.Title;
                    Check.Description=model.Description;
                    Check.Author=model.Author;
                    Check.Quantity=model.Quantity;
                    Check.Price=model.Price;
                    Check.DiscountedPrice=model.DiscountedPrice;
                    Check.BookImage=model.BookImage;
                    _context.SaveChanges();
                    return Check;
                }
                return null;


            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<BookEntity> GetBooks()
        {
            try
            {
                return _context.Book.ToList();

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public BookEntity GetBookById(int id)
        {
            try
            {
                return _context.Book.FirstOrDefault(x => x.BookId == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
