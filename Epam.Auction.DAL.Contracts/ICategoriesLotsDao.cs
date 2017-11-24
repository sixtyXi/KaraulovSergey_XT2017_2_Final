using System;
using System.Collections.Generic;
using Epam.Auction.Entities;

namespace Epam.Auction.DAL.Contracts
{
    public interface ICategoriesLotsDao
    {
        bool Create(Guid categoryId, Guid lotId);

        bool Delete(Guid lotId);

        IEnumerable<Lot> GetLotsByCategory(Guid categoryId);
    }
}
