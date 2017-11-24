using System;
using System.Collections.Generic;
using Epam.Auction.Entities;

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
