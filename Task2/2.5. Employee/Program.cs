using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Employee employee = new Employee("Jack", "Hfdg", new DateTime(1900, 12, 4), new DateTime(1901, 11, 4), "dfhrt");
                Console.WriteLine("User:");
                Console.WriteLine("     Full name: {0} {1} {2}", employee.Name, employee.Surname, employee.Patronymic);
                Console.WriteLine("     Date of Birth: {0}", employee.DoB.ToShortDateString());
                Console.WriteLine("     Age: {0}", employee.Age);
                Console.WriteLine("     Work experience: {0}", employee.WorkExperience);
                Console.WriteLine("     Position: ", employee.Position);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
