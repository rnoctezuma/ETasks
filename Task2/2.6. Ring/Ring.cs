using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.Ring
{
    public class Ring
    {
        public double X { get; set; }
        public double Y { get; set; }
        private Round innerRound;
        private Round outerRound;

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius)
                throw new ArgumentException("inner radius can't be equal or above than outer radius");

            this.X = x;
            this.Y = y;
            this.innerRound = new Round(innerRadius);
            this.outerRound = new Round(outerRadius);
        }

        public double InnerRadius
        {
            get { return this.innerRound.Radius; }
            set
            {
                if (value >= this.outerRound.Radius)
                    throw new ArgumentException("inner radius can't be equal or above than outer radius");
                this.innerRound.Radius = value;
            }
        }

        public double OuterRadius
        {
            get { return this.outerRound.Radius; }
            set
            {
                if (value <= this.innerRound.Radius)
                    throw new ArgumentException("outer radius can't be equal or lower than outer radius");
                this.outerRound.Radius = value;
            }
        }

        public double Lenght
        {
            get
            {
                return this.innerRound.Lenght + this.outerRound.Lenght;
            }
        }

        public double Area
        {
            get
            {
                return this.outerRound.Area - this.innerRound.Area;
            }
        }

    }

}
