using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
