using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.Contracts
{
    public interface ICategoryDao
    {
        bool Create(Category category);

        IEnumerable<Category> GetAll();

        Category Get(Guid id);

        bool Update(Category category);

        bool Delete(Guid id);
    }
}
