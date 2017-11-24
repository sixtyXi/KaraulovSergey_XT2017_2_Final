using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Contracts
{
    public interface ICategoryLogic
    {
        bool Add(string categoryName);

        IEnumerable<Category> GetAll();
    }
}
