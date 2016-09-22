using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.Rectangle
{
    public class Rectangle
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int AreaOfRectangle()
        {
            return Height * Width;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 'a' value: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Enter 'b' value: ");
            int width = int.Parse(Console.ReadLine());
            if (height <= 0 || width <= 0)
            {
                Console.WriteLine("Side of the rectangle should be non-negative number");
            }
            else
            {
                Rectangle rectangle = new Rectangle(height, width);
                Console.WriteLine("Area of rectangle is: {0}", rectangle.AreaOfRectangle());
            }
        }
    }
}
