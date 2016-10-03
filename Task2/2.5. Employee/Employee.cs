using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.Employee
{
    public class Employee : User
    {
        private int workExperience;
        private string position;

        public Employee(string name, string surname, string patronymic, DateTime dob, int age,
            int workExperience, string position)
            :base(name, surname, patronymic, dob, age)
        {
            this.WorkExperience = workExperience;
            this.Position = position;
        }

        public int WorkExperience
        {
            set
            {
                if (value < 0)
                    throw new ArgumentException("Work experiense can't be lower than 0");
                this.workExperience = value;
            }
            get { return this.workExperience; }

        }

        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
    }
}
