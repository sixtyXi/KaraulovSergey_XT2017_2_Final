using Epam.Auction.BLL.Contracts;
using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Core
{
    public class LotsCostsLogic : ILotsCostsLogic
    {
        private ILotsCostsDao dal;

        public LotsCostsLogic(ILotsCostsDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(Guid lotId, decimal cost)
        {
            return dal.Create(lotId, cost);
        }

        ////все ставки юзера(в т.ч. ставка при размещении лота)
        public IDictionary<Guid, decimal> GetAllBets(Guid idUser)
        {
            return dal.GetAllBets(idUser);
        }

        public decimal GetCost(Guid lotId)
        {
            return dal.GetCost(lotId);
        }

        ////цены лотов, размещенных юзером
        public IDictionary<Guid, decimal> GetPlacedLotsCost(Guid idUser)
        {
            try
            {
                return dal.GetPlacedLotsCost(idUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Guid lotId, decimal newCost)
        {
            return dal.Update(lotId, newCost);
        }

        public bool Delete(Guid lotId)
        {
            try
            {
                return dal.Delete(lotId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
