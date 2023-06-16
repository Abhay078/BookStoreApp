using CommonLayer;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class BookManager:IBookManager
    {
        private readonly IBookRepository bookRepository;
        public BookManager(IBookRepository bookRepository) 
        {
            this.bookRepository = bookRepository;
        }

        public BookEntity AddBook(AddBookModel model)
        {
            return this.bookRepository.AddBook(model);
        }

        public bool DeleteBook(int bookId)
        {
            return this.bookRepository.DeleteBook(bookId);
        }

        public BookEntity GetBookById(int id)
        {
            return this.bookRepository.GetBookById(id);
        }

        public IEnumerable<BookEntity> GetBooks()
        {
            return this.bookRepository.GetBooks();
        }

        public BookEntity UpdateBook(AddBookModel model, int bookId)
        {
            return this.bookRepository.UpdateBook(model, bookId);
        }
    }
}
