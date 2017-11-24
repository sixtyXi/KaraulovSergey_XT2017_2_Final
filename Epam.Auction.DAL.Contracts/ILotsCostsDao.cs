using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.Contracts
{
    public interface ILotsCostsDao
    {
        bool Create(Guid lotId, decimal cost);

        bool Delete(Guid lotId);

        bool Update(Guid lotId, decimal newCost);

        decimal GetCost(Guid lotId);

        IDictionary<Guid, decimal> GetPlacedLotsCost(Guid idUser);

        IDictionary<Guid, decimal> GetAllBets(Guid idUser);
    }
}
