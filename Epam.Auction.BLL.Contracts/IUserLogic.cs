using System.Collections.Generic;
using Epam.Auction.Entities;

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
