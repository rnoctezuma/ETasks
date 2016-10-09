using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.Employee
{
    public class User
    {
        private string firstname;
        private string lastname;
        private string patronymic;
        private DateTime doB;

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
                this.firstname = value;
            }
            get
            {
                return this.firstname;
            }
        }

        public string Surname
        {
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentException("Wrong surname!");
                this.lastname = value;
            }
            get
            {
                return this.lastname;
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
                return this.Calculate(this.doB);
            }
        }

        public int Calculate(DateTime date)
        {
            DateTime dateNow = DateTime.Now;
            int result = dateNow.Year - date.Year;
            if (dateNow.Month < date.Month ||
                (dateNow.Month == date.Month && dateNow.Day < date.Day)) result--;
            return result;
        }
    }
}

