using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRepo
    {
        public WishListEntity AddItem(int BookId, long UserId);
        public Boolean DeleteItem(long ItemId);
        public List<WishListEntity> GetAll();
    }
}
