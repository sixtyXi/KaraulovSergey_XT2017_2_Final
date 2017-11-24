using System;
using System.Collections.Generic;
using Epam.Auction.Entities;

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
