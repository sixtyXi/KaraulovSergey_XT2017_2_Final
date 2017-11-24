using System;
using System.Collections.Generic;
using Epam.Auction.Entities;

namespace Epam.Auction.DAL.Contracts
{
    public interface ILotsUsersDao
    {
        bool Create(Guid lotId, Guid userId);

        bool Delete(Guid lotID);

        bool Update(Guid lotId, Guid newUserId);

        IEnumerable<Lot> GetBoughtLots(Guid userId);

        IEnumerable<Lot> GetSoldLots(Guid userId);
    }
}
