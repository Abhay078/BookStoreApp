using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IOrderManager
    {
        public OrderEntity AddOrder(List<int> BookIds, long UserId);
    }
}
