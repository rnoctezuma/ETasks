using Epam.UserInfo.DalContracts;
using Epam.UserInfo.LogicContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountDao accountDao;

        public AccountLogic()
        {
            accountDao = DaoProvider.AccountDao;
        }

        public void Add(Account account)
        {
            accountDao.Add(account);
        }

        public bool CanRegister(string login)
        {
            return accountDao.CanRegister(login);
        }

        public bool CanLogin(string login, string password)
        {
            return accountDao.CheckUser(login, password);
        }

        public string GetUsersRole(string login)
        {
            return accountDao.GetRole(login);
        }
    }
}
