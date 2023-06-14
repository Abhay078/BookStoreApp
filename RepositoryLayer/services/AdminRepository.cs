using CommonLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.BookDbContext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.services
{
    public class AdminRepository:IAdminRepository
    {
        private readonly BookContext context;
        private readonly IConfiguration _config;
        public AdminRepository(BookContext context  ,IConfiguration _config) 
        {
            this.context = context;
            this._config = _config;
        }
        public AdminEntity AdminRegister(UserRegModel model)
        {
            try
            {
                AdminEntity entity = new AdminEntity();
                entity.FullName = model.FullName;
                entity.Email = model.Email;
                entity.Password = EncryptPassword(model.Password);
                entity.MobileNumber = model.MobileNumber;
                var Check = context.Admin.Add(entity);
                context.SaveChanges();

                if (Check != null)
                {

                    return entity;
                }
                return null;

            }
            catch (Exception)
            {
                throw;

            }

        }
        public string EncryptPassword(string password)
        {
            try
            {
                var PlainText = Encoding.UTF8.GetBytes(password);
                var EncodedPass = Convert.ToBase64String(PlainText);
                return EncodedPass;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public AdminEntity Login(LoginModel login)
        {
            try
            {
                var checkEmail = context.Admin.FirstOrDefault(x => x.Email == login.Email);
                if (checkEmail != null)
                {
                    var pass = context.Admin.FirstOrDefault(x => x.Password == EncryptPassword(login.Password));
                    if (pass != null)
                    {
                        return checkEmail;
                    }
                    return null;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Generate(string Email, long AdminId, string Role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim("Id",AdminId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role,Role)



            };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Audience"],
                  claims,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
