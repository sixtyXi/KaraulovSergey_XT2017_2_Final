using Epam.Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.Contracts
{
    public interface ICategoriesLotsDao
    {
        bool Create(Guid categoryId, Guid lotId);

        bool Delete(Guid lotId);

        IEnumerable<Lot> GetLotsByCategory(Guid categoryId);
    }
}
