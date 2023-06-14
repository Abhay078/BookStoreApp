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
    public class CartRepository:ICartRepository
    {
        private readonly BookContext context;
        public CartRepository(BookContext context)
        {
            this.context = context;
        }
        public CartEntity AddItemToCart(AddCartItemModel model,long UserId)
        {
            try
            {
                CartEntity cart= new CartEntity();
                cart.Quantity= model.Quantity;
                cart.BookId= model.BookId;
                cart.UserId = UserId;
                context.Cart.Add(cart);
                context.SaveChanges();
                return cart;    

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Boolean DeleteItem(long ItemId)
        {
            try
            {
                var Check=context.Cart.FirstOrDefault(x=>x.CartItemId==ItemId);
                if (Check != null)
                {
                    context.Cart.Remove(Check);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CartEntity> GetItems(long UserId)
        {
            try
            {
                return context.Cart.Where(x=>x.UserId==UserId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CartEntity UpdateQuantity(long ItemId,int quantity)
        {
            try
            {
                var Check = context.Cart.FirstOrDefault(x => x.CartItemId == ItemId);
                if (Check != null)
                {
                    Check.Quantity= quantity;
                    context.SaveChanges();
                    return Check;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
