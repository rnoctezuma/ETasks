using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class Ring : IFigure, IArea
    {
        public double X { get; set; }
        public double Y { get; set; }
        private Circle innerRound;
        private Circle outerRound;

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius)
                throw new ArgumentException("inner radius can't be equal or above than outer radius");
            this.X = x;
            this.Y = y;

            this.innerRound = new Circle(x,y,innerRadius);
            this.outerRound = new Circle(x,y,outerRadius);
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

        public double Length
        {
            get
            {
                return this.innerRound.Length + this.outerRound.Length;
            }
        }

        public double Area
        {
            get
            {
                return this.outerRound.Area - this.innerRound.Area;
            }
        }

        public string Draw()
        {
            return $"Ring: X = {this.X}, Y = {this.Y}, innerRadius = {this.innerRound.Radius}, outerRadius = {this.outerRound.Radius}";
        }
    }
}
