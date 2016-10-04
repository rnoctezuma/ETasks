using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class Ring : IFigure
    {
        public double X { get; set; }
        public double Y { get; set; }
        private RoundShape innerRound;
        private RoundShape outerRound;

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius)
                throw new ArgumentException("inner radius can't be equal or above than outer radius");
            if (outerRadius <= innerRadius)
                throw new ArgumentException("outer radius can't be equal or lower than outer radius");
            this.X = x;
            this.Y = y;
            this.innerRound = new RoundShape(innerRadius);
            this.outerRound = new RoundShape(outerRadius);
        }

        public RoundShape InnerRound
        {
            get { return this.innerRound; }
            set
            {
                if (value.Radius >= this.outerRound.Radius)
                    throw new ArgumentException("inner radius can't be equal or above than outer radius");
                this.innerRound = value;
            }
        }

        public RoundShape OuterRound
        {
            get { return this.outerRound; }
            set
            {
                if (value.Radius <= this.innerRound.Radius)
                    throw new ArgumentException("outer radius can't be equal or lower than outer radius");
                this.outerRound = value;
            }
        }

        public double GetLength
        {
            get
            {
                return this.innerRound.GetLength + this.outerRound.GetLength;
            }
        }

        public double GetArea
        {
            get
            {
                return this.outerRound.GetArea - this.innerRound.GetArea;
            }
        }

        public string Draw()
        {
            return $"Ring: X = {this.X}, Y = {this.Y}, innerRadius = {this.innerRound.Radius}, outerRadius = {this.outerRound.Radius}";
        }
    }
}
