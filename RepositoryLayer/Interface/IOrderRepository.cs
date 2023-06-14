using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRepository
    {
        public OrderEntity AddOrder(List<int> BookIds, long UserId);
    }
}
