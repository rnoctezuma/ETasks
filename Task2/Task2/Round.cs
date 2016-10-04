using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.Round
{
    public class Round
    {
        public int X { get; set; }
        public int Y { get; set; }
        private double radius;

        public Round(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public double Radius
        {
            set
            {
                if (value > 0)
                    this.radius = value;
                else
                    throw new ArgumentException("Radius must be above than 0");
            }
            get
            {
                return this.radius;
            }
        }        

        public double GetLenght
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public double GetArea
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }
    }
}
