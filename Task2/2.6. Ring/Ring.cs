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
            if (outerRadius <= innerRadius)
                throw new ArgumentException("outer radius can't be equal or lower than outer radius");
            this.X = x;
            this.Y = y;
            this.innerRound = new Round(innerRadius);
            this.outerRound = new Round(outerRadius);
        }

        public Round InnerRound
        {
            get { return this.innerRound; }
            set
            {
                if (value.Radius >= this.outerRound.Radius)
                    throw new ArgumentException("inner radius can't be equal or above than outer radius");
                this.innerRound = value;
            }
        }

        public Round OuterRound
        {
            get { return this.outerRound; }
            set
            {
                if (value.Radius <= this.innerRound.Radius)
                    throw new ArgumentException("outer radius can't be equal or lower than outer radius");
                this.outerRound = value;
            }
        }

        public double GetLenght
        {
            get
            {
                return this.innerRound.GetLenght + this.outerRound.GetLenght;
            }
        }

        public double GetArea
        {
            get
            {
                return this.outerRound.GetArea - this.innerRound.GetArea;
            }
        }

    }

}
