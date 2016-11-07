using Epam.UserInfo.DalContracts;
using Epam.UserInfo.FileDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    internal class DaoProvider
    {
        static DaoProvider()
        {
            UserDao = new FileUserDao();
            AwardDao = new FileAwardDao();
        }

        public static IUserDao UserDao { get; }
        public static IAwardDao AwardDao { get; }
    }
}