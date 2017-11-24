using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
