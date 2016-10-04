using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.Ring
{
    class Program
    {
        static void Main(string[] args)
        {           
            try
            {
                Ring ring = new Ring(1.5, 2.08, 1, 2);
                Console.WriteLine(ring.GetArea);
                Console.WriteLine(ring.GetLenght);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
