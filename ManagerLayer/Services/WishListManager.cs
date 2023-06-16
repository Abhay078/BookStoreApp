using CommonLayer;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class WishListManager:IWishListManager
    {
        private readonly IWishListRepo repo;
        public WishListManager(IWishListRepo repo)
        {
            this.repo = repo;
        }

        public WishListEntity AddItem(int BookId, long UserId)
        {
            return this.repo.AddItem( BookId,UserId);
        }

        public bool DeleteItem(int BookId)
        {
           return this.repo.DeleteItem(BookId);
        }

        public List<WishListEntity> GetAll()
        {
            return this.repo.GetAll();
        }
    }
}
