using Epam.UserInfo.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UserInfo.FileDal
{
    public class DBAwardDao : IAwardDao
    {
        public bool Add(Award award)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardsByIDs(int[] IDs)
        {
            throw new NotImplementedException();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }
    }

}
