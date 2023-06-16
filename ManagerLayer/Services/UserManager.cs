using CommonLayer;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository User;
        public UserManager(IUserRepository User) 
        {
            this.User = User;
        }
        public UserEntity UserRegister(UserRegModel model)
        {
            return this.User.UserRegister(model);
        }
        public UserEntity Login(LoginModel login)
        {
            return this.User.Login(login);
        }
        public string Generate(string Email, long Userid,string role)
        {
            return this.User.Generate(Email, Userid,role);
        }

        public AddressEntity AddAddress(AddAddressModel model,long UserId)
        {
           return this.User.AddAddress(model,UserId);
        }

        public AddressEntity UpdateAddress(AddAddressModel model, long AddressId)
        {
            return this.User.UpdateAddress(model, AddressId);
        }

        public AddressEntity GetAddress(long UserId)
        {
            return this.User.GetAddress(UserId);
        }
    }
}
