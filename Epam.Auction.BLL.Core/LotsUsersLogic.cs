using Epam.Auction.BLL.Contracts;
using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Auction.Entities;

namespace Epam.Auction.BLL.Core
{
    public class LotsUsersLogic : ILotsUsersLogic
    {
        private ILotsUsersDao dal;

        public LotsUsersLogic(ILotsUsersDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(Guid lotId, Guid userId)
        {
            return dal.Create(lotId, userId);
        }

        public bool Delete(Guid lotID)
        {
            try
            {
                return dal.Delete(lotID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        ////возвращает выигранные лоты
        public IEnumerable<Lot> GetBoughtLots(Guid idUser)
        {
            var timeNow = DateTime.Now;
            return dal.GetBoughtLots(idUser).Where((lot) => lot.ExpireDate < timeNow).ToArray();
        }

        ////возвращает проданные лоты
        public IEnumerable<Lot> GetSoldLots(Guid userId)
        {
            var timeNow = DateTime.Now;
            return dal.GetSoldLots(userId).Where((lot) => lot.ExpireDate < timeNow).ToArray();
        }



        public bool Update(Guid lotId, Guid newUserId)
        {
            return dal.Update(lotId, newUserId);
        }
    }
}
