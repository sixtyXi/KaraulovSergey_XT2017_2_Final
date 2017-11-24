using Epam.Auction.BLL.Contracts;
using Epam.Auction.DI.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Auction.PL.WebUI.Helpers
{
    public static class Providers
    {
        public static ILotLogic lotLogic = Provider.LotLogic;
        public static ICategoryLogic categoryLogic = Provider.CategoryLogic;
        public static ICategoriesLotsLogic categoriesLotsLogic = Provider.CategoriesLotsLogic;
        public static IUserLogic userLogic = Provider.UserLogic;
        public static ILotsCostsLogic lotsCostsLogic = Provider.LotsCostsLogic;
        public static ILotsUsersLogic lotsUsersLogic = Provider.LotsUsersLogic;
        public static IUsersRolesLogic usersRolesLogic = Provider.UsersRolesLogic;
    }
}