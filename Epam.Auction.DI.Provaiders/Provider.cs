using Epam.Auction.BLL.Contracts;
using Epam.Auction.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DI.Providers
{
    public static class Provider
    {
        static Provider()
        {
            LotDao = new DAL.DataBase.LotDao();
            LotLogic = new BLL.Core.LotLogic(LotDao);
            CategoryDao = new DAL.DataBase.CategoryDao();
            CategoryLogic = new BLL.Core.CategoryLogic(CategoryDao);
            CategoriesLotsDao = new DAL.DataBase.CategoriesLotsDao();
            CategoriesLotsLogic = new BLL.Core.CategoriesLotsLogic(CategoriesLotsDao);
            UserDao = new DAL.DataBase.UserDao();
            UserLogic = new BLL.Core.UserLogic(UserDao);
            LotsCostsDao = new DAL.DataBase.LotsCostsDao();
            LotsCostsLogic = new BLL.Core.LotsCostsLogic(LotsCostsDao);
            LotsUsersDao = new DAL.DataBase.LotsUsersDao();
            LotsUsersLogic = new BLL.Core.LotsUsersLogic(LotsUsersDao);
            UsersRolesDao = new DAL.DataBase.UsersRolesDao();
            UsersRolesLogic = new BLL.Core.UsersRolesLogic(UsersRolesDao);
        }

        public static ILotDao LotDao { get; }

        public static ILotLogic LotLogic { get; }

        public static ICategoryDao CategoryDao { get; }

        public static ICategoryLogic CategoryLogic { get; }

        public static ICategoriesLotsDao CategoriesLotsDao { get; }

        public static ICategoriesLotsLogic CategoriesLotsLogic { get; }

        public static IUserDao UserDao { get; }

        public static IUserLogic UserLogic { get; }

        public static ILotsCostsDao LotsCostsDao { get; }

        public static ILotsCostsLogic LotsCostsLogic { get; }

        public static ILotsUsersDao LotsUsersDao { get; }

        public static ILotsUsersLogic LotsUsersLogic { get; }

        public static IUsersRolesDao UsersRolesDao { get; }

        public static IUsersRolesLogic UsersRolesLogic { get; }
    }
}
