using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.Employee
{
    public class Employee : User
    {
        private DateTime startWorking;
        private string position;

        //constuctors
        public Employee(string name, string surname, string patronymic, DateTime dob, DateTime startWorking, string position)
            :base(name, surname, patronymic, dob)
        {
            this.StartWorking = startWorking;
            this.Position = position;
        }

        public Employee(string name, string surname, DateTime dob,
            DateTime startWorking, string position)
            : base(name, surname, dob)
        {
            this.StartWorking = startWorking;
            this.Position = position;
        }
        //////////////////////////// 

        public DateTime StartWorking
        {
            
            get { return this.startWorking; }

            set
            {
                if (value < this.DoB || value > DateTime.Now )
                    throw new ArgumentException("Invalid start working value");
                if (DateTime.Now.Year - value.Year > 150)
                    throw new ArgumentException("You are too old");
                this.startWorking = value;
            }
        }

        public int WorkExperience
        {
            get
            {
                return this.Calculate(this.startWorking);
            }
        }

        public string Position
        {
            get { return this.position; }
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentException("Wrong Position!");
                this.position = value;
            }
        }
    }
}
