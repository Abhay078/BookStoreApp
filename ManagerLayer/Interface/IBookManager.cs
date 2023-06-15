using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IBookManager
    {
        public BookEntity AddBook(AddBookModel model);
        public Boolean DeleteBook(int bookId);
        public BookEntity UpdateBook(AddBookModel model, int bookId);
        public IEnumerable<BookEntity> GetBooks();
    }
}
