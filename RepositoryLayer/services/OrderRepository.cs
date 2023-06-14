using CommonLayer;
using RepositoryLayer.BookDbContext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.services
{
    public class OrderRepository:IOrderRepository
    {
        private readonly BookContext context;
        public OrderRepository(BookContext context)
        {
            this.context = context;
        }
        public OrderEntity AddOrder(List<int> BookIds,long UserId)
        {
            try
            {
                OrderEntity entity = new OrderEntity();
                entity.UserId = UserId;
                entity.CreatedDate = DateTime.Now;

                foreach (int id in BookIds)
                {
                    var book = context.Book.Find(id);
                    if (book != null)
                    {
                        entity.Books.Add(book);
                    }

                }
                context.Order.Add(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
