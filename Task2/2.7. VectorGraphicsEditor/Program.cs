using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._7.VectorGraphicsEditor.Figures;

namespace _2._7.VectorGraphicsEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IFigure[] figures = new IFigure[5];
                figures[0] = new Rectangle(1.5, 3.6, 10.1, 8.7);
                figures[1] = new Line(1.7,1.9,-3,-10);
                figures[2] = new Round(1.8,0,17);
                figures[3] = new Circle(9.32, 0.5, 18);
                figures[4] = new Ring(-1, 0.87, 4, 5);

                for (int i = 0; i < figures.Length; i++)
                {
                    Console.WriteLine(figures[i].Draw());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
