using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Contracts
{
    public interface IUserLogic
    {
        bool Add(string userName, string userPw);

        User GetUser(string userName);

        bool IsUser(string userName, string userPw);

        IEnumerable<User> GetAllUsers();
    }
}
