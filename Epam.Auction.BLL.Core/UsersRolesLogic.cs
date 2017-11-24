using Epam.Auction.BLL.Contracts;
using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Core
{
    public class UsersRolesLogic : IUsersRolesLogic
    {
        private IUsersRolesDao dal;

        public UsersRolesLogic(IUsersRolesDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(string userName, string roleName)
        {
            try
            {
                return dal.Create(userName, roleName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string userName, string roleName)
        {
            try
            {
                return dal.Delete(userName, roleName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string[] GetAllRoles()
        {
            try
            {
                return dal.GetAllRoles();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string[] GetRolesForUser(string username)
        {
            try
            {
                return dal.GetRolesForUser(username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string[] GetAvailableRolesForUser(string username)
        {
            try
            {
                string[] allRoles = dal.GetAllRoles();
                string[] userRoles;
                try
                {
                    userRoles = dal.GetRolesForUser(username);
                }
                catch (InvalidOperationException)
                {
                    userRoles = new string[0];
                }
                return allRoles.Except(userRoles).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
