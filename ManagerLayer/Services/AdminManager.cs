using CommonLayer;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository adminRepository;
        public AdminManager(IAdminRepository adminRepository) 
        {
            this.adminRepository = adminRepository;
        }
        public AdminEntity AdminRegister(UserRegModel model)
        {
            return this.adminRepository.AdminRegister(model);
        }

        public string EncryptPassword(string password)
        {
            return this.adminRepository.EncryptPassword(password);
        }

        public string Generate(string Email, long AdminId, string Role)
        {
            return this.adminRepository.Generate(Email, AdminId, Role);
        }

        public AdminEntity Login(LoginModel login)
        {
            return this.adminRepository.Login(login);
        }
    }
}
