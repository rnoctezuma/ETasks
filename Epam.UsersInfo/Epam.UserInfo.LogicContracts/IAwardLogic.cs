using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.LogicContracts
{
    public interface IAwardLogic
    {
        Award[] GetAll();

        Award[] GetAwardsByIDs(int[] IDs);

        bool Save(Award newAward);

        int GetMaxId();
    }
}