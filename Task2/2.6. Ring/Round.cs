using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.Ring
{
    public class Round
    {
        private double radius;

        public Round(double radius)
        {
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

        public double Lenght
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }
    }
}
