using Epam.Auction.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Auction.Entities;
using Epam.Auction.DAL.Contracts;

namespace Epam.Auction.BLL.Core
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDao dal;

        public CategoryLogic(ICategoryDao DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL as parameter is null");
            }

            dal = DAL;
        }

        public bool Add(string categoryName)
        {
            var newCategory = new Category()
            {
                Id = Guid.NewGuid(),
                Name = categoryName
            };

            try
            {
                return dal.Create(newCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return dal.GetAll().ToArray();
        }
    }
}
