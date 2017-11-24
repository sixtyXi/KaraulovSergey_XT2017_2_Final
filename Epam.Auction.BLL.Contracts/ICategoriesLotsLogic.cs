using System;
using System.Collections.Generic;
using Epam.Auction.Entities;

namespace Epam.Auction.BLL.Contracts
{
    public interface ICategoriesLotsLogic
    {
        bool Add(Guid categoryId, Guid lotId);

        IEnumerable<Lot> GetLotsByCategory(Guid categoryId);

        IEnumerable<Lot> GetLotsByCategory(Guid categoryId, string lotName);

        IEnumerable<Lot> GetNewLotsByCategoryAndName(Guid categoryId, string lotName);

        IEnumerable<Lot> GetNewLotsByCategory(Guid categoryId);

        bool Delete(Guid lotId);
    }
}
