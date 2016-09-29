using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._8.NoPositive
{
    class Program
    {
        static Random Rnd = new Random();
        static int[,,] InitArray()
        {
            int[,,] array3D = new int[2, 3, 4];
            for (int i = 0; i < array3D.GetLength(0); i++)
                for (int j = 0; j < array3D.GetLength(1); j++)
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        array3D[i, j, k] = Rnd.Next(-100, 100);
                    }
            return array3D;
        }

        static void ChangeNegativeElems(int[,,] array3D)
        {
            for (int i = 0; i < array3D.GetLength(0); i++)
                for (int j = 0; j < array3D.GetLength(1); j++)
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        if (array3D[i, j, k] > 0)
                            array3D[i, j, k] = 0;
                    }
        }

        static void printArray3D(int[,,] array3D)
        {
            for (int i = 0; i < array3D.GetLength(0); i++)
                for (int j = 0; j < array3D.GetLength(1); j++)
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        Console.Write(" {0}", array3D[i, j, k]);
                    }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            
            int[,,] array3D = InitArray();

            Console.Write("Source array: ");
            printArray3D(array3D);
            ChangeNegativeElems(array3D);
            Console.Write("Modified array: ");
            printArray3D(array3D);
        }
    }
}
