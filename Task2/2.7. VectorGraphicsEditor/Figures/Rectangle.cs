using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class Rectangle : IFigure, IArea
    {
        private double width;
        private double height;

        public double X { get; set; }
        public double Y { get; set; }

        public Rectangle(double x, double y, double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("width and height must be above than 0");
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;

        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("width must be above than 0");
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("height must be above than 0");
                this.height = value;
            }
        }

        public double Length
        {
            get
            {
                return this.height * 2 + this.width * 2;
            }
        }

        public double Area
        {
            get
            {
                return this.height * this.width;
            }
        }

        public string Draw()
        {
            return $"Rectangle: X = {this.X}, Y = {this.Y}, Width = {this.Width}, Height = {this.Height}";
        }
    }
}
