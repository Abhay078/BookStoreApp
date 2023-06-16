using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRepository
    {
        public UserEntity UserRegister(UserRegModel model);
        public UserEntity Login(LoginModel login);
        public string Generate(string Email, long Userid,string role);
        public AddressEntity AddAddress(AddAddressModel model, long UserId);
        public AddressEntity UpdateAddress(AddAddressModel model, long AddressId);
        public AddressEntity GetAddress(long UserId);
    }
}
