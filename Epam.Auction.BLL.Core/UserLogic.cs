using Epam.Auction.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Auction.Entities;
using Epam.Auction.DAL.Contracts;
using System.Security.Cryptography;

namespace Epam.Auction.BLL.Core
{
    public class UserLogic : IUserLogic
    {
        private IUserDao dal;

        public UserLogic(IUserDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(string userName, string userPw)
        {
            if (!dal.IsUserExist(userName))
            {
                var salt = Guid.NewGuid();
                var hash = this.GetHash(Encoding.UTF8.GetBytes(userPw), salt.ToByteArray());
                User newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = userName,
                    Hash = hash,
                    Salt = salt
                };

                return dal.Create(newUser);
            }

            return false;
        }

        public bool IsUser(string userName, string userPw)
        {
            try
            {
                User targetUser = dal.GetUser(userName);
                byte[] hashUser = this.GetHash(Encoding.UTF8.GetBytes(userPw), targetUser.Salt.ToByteArray());
                return hashUser.IsEqual(targetUser.Hash);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUser(string userName)
        {
            try
            {
                return dal.GetUser(userName);   
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] GetHash(byte[] pw, byte[] salt)
        {
            byte[] saltedPw = new byte[pw.Length + salt.Length];
            pw.CopyTo(saltedPw, 0);
            salt.CopyTo(saltedPw, pw.Length);
            HashAlgorithm algorithm = new SHA256Managed();
            return algorithm.ComputeHash(saltedPw);
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return dal.GetAllUsers().ToArray();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
