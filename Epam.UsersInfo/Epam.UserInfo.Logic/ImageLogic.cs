using Epam.UserInfo.DalContracts;
using Epam.UserInfo.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UserInfo.Logic
{
    public class ImageLogic : IImageLogic
    {
        private IImageDao imageDao;

        public ImageLogic()
        {
            imageDao = DaoProvider.ImageDao;
        }

        public bool AddImageToUser(int ID, Photo photo)
        {
            return imageDao.AddUsersPhoto(ID, photo);
        }

        public bool AddImageToAward(int ID, Photo photo)
        {
            return imageDao.AddAwardsPhoto(ID, photo);
        }     

        public Photo GetSmallPhoto(int ID)
        {
            return imageDao.GetSmallPhoto(ID);
        }
    }
}
