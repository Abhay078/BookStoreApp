﻿using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IWishListManager
    {
        public WishListEntity AddItem(int BookId, long UserId);
        public Boolean DeleteItem(int BookId);
        public List<WishListEntity> GetAll();
    }
}
