using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.User
{
    public class User
    {
        private string name;
        private string surname;
        private string patronymic;
        private int age;
        public DateTime DoB { get; set; }

        public User (string name, string surname, string patronymic, DateTime dob, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.DoB = dob;
            this.Age = age;
        }

        public string Name
        {           
            set
            {
                if (value.Length > 1000)
                    throw new ArgumentException("Name is too long");
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i]))
                        throw new ArgumentException("Name may contain only letters.");
                }
                this.name = value;
            }
            get
            {
                return this.name;
            }
        }

        public string Surname
        {
            set
            {
                if (value.Length > 1000)
                    throw new ArgumentException("Name is too long");
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i]))
                        throw new ArgumentException("Surname may contain only letters.");
                }
                this.surname = value;
            }
            get
            {
                return this.surname;
            }
        }

        public string Patronymic
        {
            set
            {
                if (value.Length > 1000)
                    throw new ArgumentException("Name is too long");
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i]))
                        throw new ArgumentException("Patronymic may contain only letters.");
                }
                this.patronymic = value;
            }
            get
            {
                return this.patronymic;
            }
        }

        public int Age
        {
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age can't be negative");
                if (value > 120)
                    throw new ArgumentException("You are too old");
                this.age = value;
            }
            get
            {
                return this.age;
            }
        }
    }
}
