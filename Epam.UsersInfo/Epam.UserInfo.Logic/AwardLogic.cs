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

        public Award[] GetAwardsByIDs(int[] IDs)
        {
            if (IDs.Length==0)
            {
                Console.Write("None");
                return new Award[0];
            }

            return awardDao.GetAwardsByIDs(IDs).ToArray();
        }
        
        public int GetMaxId()
        {
            return awardDao.GetMaxId();
        }

        public bool Save(Award newAward)
        {
            if (newAward.Title.Contains('|'))
                throw new ArgumentException("Award info can't contains symbol '|'");

            if (awardDao.Add(newAward))
            {
                return true;
            }

            throw new InvalidOperationException("Error on award saving");
        }
    }
}