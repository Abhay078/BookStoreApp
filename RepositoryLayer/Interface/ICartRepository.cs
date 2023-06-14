using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepository
    {
        public CartEntity AddItemToCart(AddCartItemModel model, long UserId);
        public Boolean DeleteItem(long ItemId);
        public List<CartEntity> GetItems(long UserId);
        public CartEntity UpdateQuantity(long ItemId, int quantity);
    }
}
