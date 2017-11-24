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
    public class CategoriesLotsLogic : ICategoriesLotsLogic
    {
        private ICategoriesLotsDao dal;

        public CategoriesLotsLogic(ICategoriesLotsDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(Guid categoryId, Guid lotId)
        {
            return dal.Create(categoryId, lotId);
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

        public IEnumerable<Lot> GetLotsByCategory(Guid categoryId)
        {
            return dal.GetLotsByCategory(categoryId).ToArray();
        }

        public IEnumerable<Lot> GetNewLotsByCategory(Guid categoryId)
        {
            var timeNow = DateTime.Now;
            return this.GetLotsByCategory(categoryId).Where((lot) => lot.ExpireDate > timeNow).ToArray();
        }

        public IEnumerable<Lot> GetLotsByCategory(Guid categoryId, string lotName)
        {
            return dal.GetLotsByCategory(categoryId).Where((lot)=>lot.Name.ToLower() == lotName.ToLower()).ToArray();
        }

        public IEnumerable<Lot> GetNewLotsByCategoryAndName(Guid categoryId, string lotName)
        {
            var timeNow = DateTime.Now;
            return this.GetLotsByCategory(categoryId, lotName).Where((lot) => lot.ExpireDate > timeNow).ToArray();
        }
    }
}
