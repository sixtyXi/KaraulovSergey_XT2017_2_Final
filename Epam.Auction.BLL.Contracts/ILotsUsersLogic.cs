using System;
using System.Collections.Generic;
using Epam.Auction.Entities;

namespace Epam.Auction.BLL.Contracts
{
    public interface ILotsUsersLogic
    {
        bool Add(Guid lotId, Guid userId);

        bool Update(Guid lotId, Guid newUserId);

        IEnumerable<Lot> GetBoughtLots(Guid idUser);

        IEnumerable<Lot> GetSoldLots(Guid userId);

        bool Delete(Guid lotID);
    }
}
