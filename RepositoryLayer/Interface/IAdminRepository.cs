using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRepository
    {
        public AdminEntity AdminRegister(UserRegModel model);
        public string EncryptPassword(string password);
        public AdminEntity Login(LoginModel login);
        public string Generate(string Email, long AdminId, string Role);
    }
}
