using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.BookDbContext
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<AdminEntity> Admin { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<WishListEntity> WishList { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
    }
}
