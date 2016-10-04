using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class Circle : RoundShape
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Circle (double x, double y, double radius) : base(radius)
        {
            this.X = x;
            this.Y = y;
        }

        public override string Draw()
        {
            return $"Circle: X = {this.X}, Y = {this.Y}, Radius = {this.Radius}";
        }
    }
}
