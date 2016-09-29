using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.Round
{
    public class Round
    {
        private int x;
        private int y;
        private int radius;

        public int X
        {
            set
            {
                this.x = value;
            }
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            set
            {
                this.y = value;
            }
            get
            {
                return this.y;
            }
        }

        public int Radius
        {
            set
            {
                if (value > 0)
                    this.radius = value;
                else
                    throw new Exception("Radius must be above than 0");
            }
            get
            {
                return this.radius;
            }
        }

        public Round () {}

        public Round(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
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
