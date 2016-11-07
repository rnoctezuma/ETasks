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
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao awardDao;

        public AwardLogic()
        {
            awardDao = DaoProvider.AwardDao;
        }

        public Award[] GetAll()
        {
            return awardDao.GetAll().ToArray();
        }

        public bool Save(string newAward)
        {
            if (newAward.Contains('|'))
                throw new ArgumentException("Award info can't contains symbol '|'");

            Award award = new Award { Title = newAward };

            if (awardDao.Add(award))
            {
                return true;
            }

            throw new InvalidOperationException("Error on award saving");
        }
    }
}