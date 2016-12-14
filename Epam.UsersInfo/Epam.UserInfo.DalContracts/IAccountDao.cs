using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.DalContracts
{
    public interface IAccountDao
    {
        bool Add(Account account);

        bool CanRegister(string login);

        bool CheckUser(string login, string password);

        string GetRole(string login);

        Account GetByID(int id);

        bool Contains(int id);

        bool ChangeRole(int id);

        IEnumerable<Account> GetAll();
    }
}