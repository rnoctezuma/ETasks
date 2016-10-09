using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class Circle : IArea, IFigure
    {
        public double X { get; set; }
        public double Y { get; set; }
        private double radius;

        public Circle (double x, double y, double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must be above than 0");
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius must be above than 0");
                this.radius = value;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }

        public double Length
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public string Draw()
        {
            return $"Circle: X = {this.X}, Y = {this.Y}, Radius = {this.Radius}";
        }
    }
}
