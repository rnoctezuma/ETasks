using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Epam.UsersInfo.Entities;

namespace Epam.UserInfo.DalContracts
{
    public interface IImageDao
    {
        bool AddUsersPhoto(int ID, Photo photo);

        bool AddAwardsPhoto(int ID, Photo photo);

        Photo GetSmallPhoto(int ID);
    }
}
