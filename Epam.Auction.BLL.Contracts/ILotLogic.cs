using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Contracts
{
    public interface ILotLogic
    {
        bool Add(Lot lot);

        IEnumerable<Lot> GetAll();

        Lot Get(Guid id);

        IEnumerable<Lot> GetLotsByName(string lotName);

        IEnumerable<Lot> GetLots(int index, int count, out bool end);

        IEnumerable<Lot> GetNewLots(int index, int count, out bool end);

        IEnumerable<Lot> GetActiveLotsByUserIdTimeNow(Guid userId);

        bool Delete(Guid lotId);

        IEnumerable<Lot> GetNewLotsByName(string lotName);
    }
}
