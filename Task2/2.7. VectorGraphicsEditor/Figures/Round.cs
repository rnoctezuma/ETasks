using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    public class Round : IFigure
    {
        public double X { get; set; }
        public double Y { get; set; }
        private double radius;

        public Round(double x, double y, double radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }

            set
            {
                if (value > 0)
                    this.radius = value;
                else
                    throw new ArgumentException("Radius must be above than 0");
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
            return $"Round: X = {this.X}, Y = {this.Y}, Radius = {this.Radius}";
        }
    }
}
