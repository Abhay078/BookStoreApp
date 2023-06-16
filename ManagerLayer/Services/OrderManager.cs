using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository repository;
        public OrderManager(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public OrderEntity AddOrder(List<int> BookIds, long UserId)
        {
            return this.repository.AddOrder(BookIds, UserId);
        }
    }
}
