using Epam.UserInfo.DalContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Epam.UserInfo.Dal.DBDao
{
    public class DBImageDao : IImageDao
    {
        private static string connectionStr;

        static DBImageDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool AddUsersPhoto(int ID, Photo photo)
        {
            int newImageID = SavePhoto(photo);
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE db.[User] SET ImageID=@imageID WHERE ID=@id";

                cmd.Parameters.AddWithValue("@imageID", newImageID);
                cmd.Parameters.AddWithValue("@id", ID);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool AddAwardsPhoto(int ID, Photo photo)
        {
            int newImageID = SavePhoto(photo);
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE db.[Award] SET ImageID=@imageID WHERE ID=@id";

                cmd.Parameters.AddWithValue("@imageID", newImageID);
                cmd.Parameters.AddWithValue("@id", ID);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Photo GetFullImage(int ID)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Image, ContentType FROM db.Image WHERE ID=@id";
                command.Parameters.AddWithValue("@id", ID);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Photo((byte[])reader["Image"], (string)reader["ContentType"]);
                }
                return null;
            }
        }

        public Photo GetSmallPhoto(int ID)
        {
            var photo = GetFullImage(ID);
            try
            {
                var image = ImageHelper.Resize(Image.FromStream(new MemoryStream(photo.Data)), 32, 32, reduceOnly: true);
                var memStr = new MemoryStream();
                image.Save(memStr, GetFormat(photo.ContentType));

                photo.Data = memStr.ToArray();
                return photo;
            }
            catch
            {
                return photo;
            }
        }

        private static ImageFormat GetFormat(string format)
        {
            var extension = format.Split('/').Last();
            switch (extension)
            {
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                case "bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Png;
            }
        }

        private static int SavePhoto(Photo photo)
        {
            try
            {
                using (var connection = new SqlConnection(connectionStr))
                {
                    MemoryStream ms = new MemoryStream(photo.Data);
                    Image image = Image.FromStream(ms);

                    var memStr = new MemoryStream();
                    image.Save(memStr, GetFormat(photo.ContentType));
                    var data = memStr.ToArray();

                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO db.Image (Image, ContentType) VALUES (@image, @contentType); SELECT scope_identity()";
                    command.Parameters.AddWithValue("@image", data);
                    command.Parameters.AddWithValue("@contentType", photo.ContentType);

                    connection.Open();
                    return (int)(decimal)command.ExecuteScalar();
                }
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
