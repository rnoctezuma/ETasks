using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.Round
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.Write("Enter 'x' coordinate: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Enter 'y' coordinate: ");
                int y = int.Parse(Console.ReadLine());
                Console.Write("Enter 'radius' value: ");
                int radius = int.Parse(Console.ReadLine());
                Round round = new Round(x,y,radius);

                Console.WriteLine();
                Console.WriteLine("Area of round: {0:#.##}", round.GetArea);
                Console.WriteLine("Lenght of round: {0:#.##}", round.GetLenght);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
