using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.User
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User("gfhtre", "dher", "dfhbrt", new DateTime(1990, 12, 4), 18);
                Console.WriteLine("User:");
                Console.WriteLine("     Full name: {0} {1} {2}", user.Name, user.Surname, user.Patronymic);
                Console.WriteLine("     Date of Birth: {0}", user.DoB.ToShortDateString());
                Console.WriteLine("     Age: {0}", user.Age);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
