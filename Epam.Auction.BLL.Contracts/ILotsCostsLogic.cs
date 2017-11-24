using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Contracts
{
    public interface ILotsCostsLogic
    {
        bool Add(Guid lotId, decimal cost);

        bool Update(Guid lotId, decimal newCost);

        decimal GetCost(Guid lotId);

        IDictionary<Guid, decimal> GetPlacedLotsCost(Guid idUser);

        IDictionary<Guid, decimal> GetAllBets(Guid idUser);

        bool Delete(Guid lotId);
    }
}
