﻿using ITSupport.Core.Contract;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Services.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IRepository<UserRole> _userRoleRepository;

        public UserService(IUserRepository userRepository, IRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }


        private string HashPasword(string Password, out string salt)
        {
            salt = CreateSalt(64);
            string stringDataToHash = Password + "" + salt;
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(stringDataToHash);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            string base64 = Convert.ToBase64String(bytHash);
            return base64;
        }
        public string CreateUser(UserViewModel model)
        {
            if (_userRepository.Collection().Where(x => x.UserName == model.UserName && !x.IsDeleted).Any())
            {
                return "UserName already exists.";
            }
            if (_userRepository.Collection().Where(x => x.Email == model.Email && !x.IsDeleted).Any())
            {
                return "Email already exists.";
            }
            User user = new User();
            string salt = "";
            string password = HashPasword(model.Password, out salt);
            user.Name = model.Name;
            user.UserName = model.UserName;
            user.Email = model.Email;

            user.Password = password;
            user.PasswordSalt = salt;
            user.Gender = model.Gender;
            user.MobileNumber = model.MobileNumber;

            _userRepository.Instert(user);
            _userRepository.Commit();
            UserRole userRole = new UserRole();
            userRole.RoleId = model.RoleId;
            userRole.UserId = user.Id;
            _userRoleRepository.Insert(userRole);
            _userRoleRepository.Commit();


            return null;
        }

        public void DeleteUser(Guid Id)
        {
            UserViewModel model = new UserViewModel();
            var user = _userRepository.Collection().Where(x => x.Id == Id).FirstOrDefault();
            user.IsDeleted = true;
            _userRepository.Update(user);
            _userRepository.Commit();
            var userRole = _userRoleRepository.Collection().Where(x => x.UserId == Id).FirstOrDefault();
            userRole.IsDeleted = true;
            _userRoleRepository.Update(userRole);
            _userRoleRepository.Commit();
        }

        public string EditUser(UserViewModel model)
        {
            if (_userRepository.Collection().Where(x => x.Id != model.Id && x.UserName == model.UserName && !x.IsDeleted).Any())
            {
                return "UserName already exists.";
            }
            if (_userRepository.Collection().Where(x => x.Id != model.Id && x.Email == model.Email && !x.IsDeleted).Any())
            {
                return "Email already exists.";
            }
            var user = _userRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            user.Name = model.Name;
            user.UserName = model.UserName;
            user.Email = model.Email;
            //user.Password = model.Password;
            user.Gender = model.Gender;
            user.MobileNumber = model.MobileNumber;
            user.UpdatedOn = DateTime.Now;
            _userRepository.Update(user);
            _userRepository.Commit();

            var userRole = _userRoleRepository.Collection().Where(x => x.UserId == model.Id).FirstOrDefault();
            userRole.RoleId = model.RoleId;
            userRole.UpdatedOn = DateTime.Now;
            _userRoleRepository.Update(userRole);
            _userRoleRepository.Commit();

            return null;

        }
        public UserViewModel GetUser(Guid Id)
        {
            return _userRepository.GetUserById(Id);
        }

        public List<UserViewModel> GetUsers()
        {
            //return _userRepository.Collection().Where(x => !x.IsDeleted).ToList();
            return _userRepository.GetUsers();

        }

    }

    public interface IUserService
    {
        List<UserViewModel> GetUsers();
        UserViewModel GetUser(Guid Id);
        string CreateUser(UserViewModel model);
        string EditUser(UserViewModel model);
        void DeleteUser(Guid Id);

    }


}

