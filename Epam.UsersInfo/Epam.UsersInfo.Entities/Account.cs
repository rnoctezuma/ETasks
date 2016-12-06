using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersInfo.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public Account(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
