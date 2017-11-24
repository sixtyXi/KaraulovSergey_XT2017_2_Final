using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.Contracts
{
    public interface IUsersRolesDao
    {
        string[] GetAllRoles();

        string[] GetRolesForUser(string username);

        bool Create(string userName, string roleName);

        bool Delete(string userName, string roleName);
    }
}
