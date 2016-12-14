using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.LogicContracts
{
    public interface IImageLogic
    {
        bool AddImageToUser(int ID, Photo photo);

        bool AddImageToAward(int ID, Photo photo);

        Photo GetSmallPhoto(int ID);
    }
}
