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
    public class UserRepository:IUserRepository
    {
        private readonly BookContext context;
        private readonly IConfiguration _config;
        public UserRepository(BookContext context,IConfiguration _config) 
        {
            this.context = context;
            this._config= _config;
        }
        public UserEntity UserRegister(UserRegModel model)
        {
            try
            {
                UserEntity entity = new UserEntity();
                entity.FullName = model.FullName;
                entity.Email = model.Email;
                entity.Password = EncryptPassword(model.Password);
                entity.MobileNumber= model.MobileNumber;
                var Check = context.User.Add(entity);
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
        public UserEntity Login(LoginModel login)
        {
            try
            {
                var checkEmail=context.User.FirstOrDefault(x=>x.Email==login.Email);
                if (checkEmail!=null)
                {
                    var pass=context.User.FirstOrDefault(x=>x.Password==EncryptPassword(login.Password));
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

        public string Generate(string Email, long Userid,string Role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim("Id",Userid.ToString()),
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

        public AddressEntity AddAddress(AddAddressModel model, long UserId)
        {
            try
            {
                AddressEntity address = new AddressEntity();
                address.Address = model.Address;
                address.City = model.City;
                address.State=model.State;
                address.type = model.type;
                address.UserId = UserId;
                context.Address.Add(address);
                context.SaveChanges();
                return address;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddressEntity UpdateAddress(AddAddressModel model,long AddressId)
        {
            try
            {
                var Check=context.Address.FirstOrDefault(x=>x.AddressId==AddressId);
                if (Check != null)
                {
                    Check.Address=model.Address;
                    Check.City=model.City;
                    Check.State=model.State;
                    Check.type= model.type;
                    context.SaveChanges();
                    return Check;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
