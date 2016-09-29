using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter 1st triangle's side: ");
                int firstSide = int.Parse(Console.ReadLine());
                Console.Write("Enter 2nd triangle's side: ");
                int secondSide = int.Parse(Console.ReadLine());
                Console.Write("Enter 3rd triangle's side: ");
                int thirdSide = int.Parse(Console.ReadLine());
                Triangle triangle = new Triangle(firstSide, secondSide, thirdSide);

                Console.WriteLine("Area of triangle: {0:0.00}", triangle.GetArea);
                Console.WriteLine("Perimeter of triangle: {0}", triangle.GetPerimeter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
