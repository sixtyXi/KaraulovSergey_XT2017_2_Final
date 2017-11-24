using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Contracts
{
    public interface IUsersRolesLogic
    {
        string[] GetAllRoles();

        string[] GetRolesForUser(string username);

        string[] GetAvailableRolesForUser(string username);

        bool Add(string userName, string roleName);

        bool Delete(string userName, string roleName);
    }
}
