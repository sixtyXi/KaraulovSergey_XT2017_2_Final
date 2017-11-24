using System.Collections.Generic;
using Epam.Auction.Entities;

namespace Epam.Auction.BLL.Contracts
{
    public interface ICategoryLogic
    {
        bool Add(string categoryName);

        IEnumerable<Category> GetAll();
    }
}
