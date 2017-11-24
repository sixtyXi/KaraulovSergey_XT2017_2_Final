using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.Contracts
{
    public interface ILotDao
    {
        bool Create(Lot lot);

        IEnumerable<Lot> GetAll();

        Lot Get(Guid id);

        bool Delete(Guid id);
    }
}
