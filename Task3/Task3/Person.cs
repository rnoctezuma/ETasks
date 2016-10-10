using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Person
    {
        private int number;

        public Person(int number)
        {
            this.number = number;
        }
        public string ShowPerson()
        {
            return $"Number {this.number}; ";
        }

    }
}
