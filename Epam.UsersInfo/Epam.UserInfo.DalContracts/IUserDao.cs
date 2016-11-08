using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.DalContracts
{
    public interface IUserDao
    {
        bool Add(User user);

        IEnumerable<User> GetAll();

        int [] GetUserAwardsIDs(int ID);

        bool Remove(int id);

        bool AddUserAward(int userID, int awardID);

        bool Contains(int id);
    }
}