using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.Employee
{
    public class User
    {
        private string name;
        private string surname;
        private string patronymic;
        private DateTime doB;
        private int age;

        public User(string name, string surname, string patronymic, DateTime dob)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.DoB = dob;
        }

        public User(string name, string surname, DateTime dob)
        {
            this.Name = name;
            this.Surname = surname;
            this.DoB = dob;
        }

        public string Name
        {
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentException("Wrong name!");
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
                if (value == "" || value == null)
                    throw new ArgumentException("Wrong surname!");
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
                if (value == "" || value == null)
                    throw new ArgumentException("Wrong patronymic!");
                this.patronymic = value;
            }
            get
            {
                return this.patronymic;
            }
        }

        public DateTime DoB
        {
            get
            {
                return this.doB;
            }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Date of Birth can't be above than current date");
                if (DateTime.Now.Year - value.Year > 150)
                    throw new ArgumentException("You are too old");

                this.doB = value;
            }
        }

        public int Age
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                this.age = dateNow.Year - DoB.Year;
                if (dateNow.Month < DoB.Month ||
                    (dateNow.Month == DoB.Month && dateNow.Day < DoB.Day)) this.age--;
                return this.age;
            }
        }
    }
}

