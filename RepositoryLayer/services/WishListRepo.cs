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
    public class WishListRepo:IWishListRepo
    {
        private readonly BookContext context;
        public WishListRepo(BookContext context)
        {
            this.context = context;
        }
        public WishListEntity AddItem(int BookId,long UserId)
        {
            try
            {
                WishListEntity Item = new WishListEntity();
                Item.BookId = BookId;
                Item.UserId = UserId;
                context.WishList.Add(Item);
                context.SaveChanges();
                return Item;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
        public Boolean DeleteItem(int bookId)
        {
            try
            {
                var check=context.WishList.FirstOrDefault(x=>x.BookId==bookId);
                if(check!=null)
                {
                    context.WishList.Remove(check);
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
        public List<WishListEntity> GetAll()
        {
            try
            {
                return context.WishList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
