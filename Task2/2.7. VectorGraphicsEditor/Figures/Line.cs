using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class Line : IFigure
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Line(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        double IFigure.GetArea
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double GetLength
        {
            get
            {
                return Math.Sqrt((this.X2 - this.X1) * (this.X2 - this.X1) + (this.Y2 - this.Y1) * (this.Y2 - this.Y1));
            }
        }

        public string Draw()
        {
            return $"Line: X1 = {this.X1}, Y1 = {this.Y1}, X2 = {this.X2}, Y2 = {this.Y2}";
        }

        
    }
}
