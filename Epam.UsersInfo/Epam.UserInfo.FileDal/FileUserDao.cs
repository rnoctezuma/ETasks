using Epam.UserInfo.DalContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.FileDal
{
    public class FileUserDao : IUserDao
    {
        private const string DateFormat = "dd/MM/yyyy";
        private readonly string fileName;
        private readonly string counterFileName;

        public FileUserDao()
        {
            fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.txt");
            counterFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usersCounter.txt");
        }

        public bool Add(User user)
        {
            user.Id = GetMaxId() + 1;
            File.WriteAllText(counterFileName, user.Id.ToString());
            string dob = String.Format("{0}/{1}/{2}", user.DateOfBirth.Day, user.DateOfBirth.Month, user.DateOfBirth.Year);
            File.AppendAllLines(fileName, new[] { $"{user.Id}|{user.Name}|{dob}|" });
            return true;
        }

        public int GetMaxId()
        {
            try
            {
                return int.Parse(File.ReadAllText(counterFileName, Encoding.Default));
            }
            catch
            {
                File.WriteAllText(counterFileName, "0");
                return 0;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return File.ReadAllLines(fileName)
                .Select(s => s.Split('|'))
                .Select(parts => new User
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    DateOfBirth = DateTime.Parse(parts[2]),
                    AwardsID = parts[3].Split('^').Select(s =>
                    {
                        if (s == String.Empty)
                            return -1;
                        else
                            return s.Select(id => 1);
                    }),
                });
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public bool Remove(int id)
        {
            var lines = File.ReadAllLines(fileName).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(id - 1);
                }
            }
            File.WriteAllLines(fileName, lines.ToArray(), Encoding.Default);
            return true;
        }
    }
}