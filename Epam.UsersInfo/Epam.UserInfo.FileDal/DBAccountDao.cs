using Epam.UserInfo.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.UserInfo.FileDal
{
    public class DBAccountDao : IAccountDao
    {
        private static string connectionStr;

        static DBAccountDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(Account account)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO db.Account (Login, Password) VALUES (@login, @password); SELECT scope_identity()";
                cmd.Parameters.AddWithValue("@login", account.Login);
                cmd.Parameters.AddWithValue("@password", GetPasswordsHash(account.Password));
                connection.Open();
        
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public void SetRole(int ID)
        {
            throw new NotImplementedException();
        }

        public bool CanRegister(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Login FROM db.Account WHERE Login=@login";
                cmd.Parameters.AddWithValue("@login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return !reader.Read();
            }
        }

        public bool CheckUser(string login, string password)
        {
            using (var connection = new SqlConnection(connectionStr))
            {

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Login, Password FROM db.Account WHERE (Login=@login) AND  (Password=@password)";
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", GetPasswordsHash(password));
                connection.Open();

                var reader = cmd.ExecuteReader();
                return reader.Read();
            }
        }
        
        public string GetRole(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT RoleName FROM db.Role WHERE ID IN (SELECT RoleID FROM db.Account WHERE Login = @login)";
                cmd.Parameters.AddWithValue("@login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();
                string role = "";
                while (reader.Read())
                {
                    role = (string)reader["RoleName"];
                }
                return role;
            }
        }

        private static string GetPasswordsHash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
