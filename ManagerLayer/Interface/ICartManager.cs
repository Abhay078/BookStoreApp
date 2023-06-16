using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface ICartManager
    {
        public CartEntity AddItemToCart(AddCartItemModel model, long UserId);
        public Boolean DeleteItem(int BookId);
        public List<CartEntity> GetItems(long UserId);
        public CartEntity UpdateQuantity(long ItemId, int quantity);
    }
}
