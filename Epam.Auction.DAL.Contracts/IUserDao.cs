using System.Collections.Generic;
using Epam.Auction.Entities;

namespace Epam.Auction.DAL.Contracts
{
    public interface IUserDao
    {
        bool Create(User user);

        User GetUser(string name);

        bool IsUserExist(string userName);

        IEnumerable<User> GetAllUsers();
    }
}
