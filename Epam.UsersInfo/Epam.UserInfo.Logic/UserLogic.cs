using Epam.UserInfo.DalContracts;
using Epam.UserInfo.LogicContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;

        public UserLogic()
        {
            userDao = DaoProvider.UserDao;
        }

        public bool Delete(int id)
        {
            return userDao.Remove(id);
        }

        public User[] GetAll()
        {
            return userDao.GetAll().ToArray();
        }

        public bool Save(string newUser)
        {
            if (newUser.Where(ch => ch == '|').Count() > 1)
                throw new ArgumentException("User info can't contains symbol '|'");
            var tempUser = newUser.Split('|');

            DateTime dob = DateTime.ParseExact(tempUser[1], "dd/MM/yyyy", CultureInfo.CurrentCulture);
            if (dob > DateTime.Today)
            {
                throw new ArgumentException("Date of Birth can't be above than current date");
            }

            User user = new User { Name = tempUser[0], DateOfBirth = dob };

            if (userDao.Add(user))
            {
                return true;
            }

            throw new InvalidOperationException("Error on user saving");
        }
    }
}