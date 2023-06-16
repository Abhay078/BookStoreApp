using CommonLayer;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class CartManager:ICartManager
    {
        private readonly ICartRepository repository;
        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }

        public CartEntity AddItemToCart(AddCartItemModel model, long UserId)
        {
            return this.repository.AddItemToCart(model, UserId);
        }

        public bool DeleteItem(int BookId)
        {
            return repository.DeleteItem(BookId);
        }

        public List<CartEntity> GetItems(long UserId)
        {
            return this.repository.GetItems(UserId);
        }

        public CartEntity UpdateQuantity(long ItemId, int quantity)
        {
            return this.repository.UpdateQuantity(ItemId, quantity);
        }
    }
}
