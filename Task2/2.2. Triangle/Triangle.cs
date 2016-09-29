using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.Triangle
{
    public class Triangle
    {
        private int firstSide;
        private int secondSide;
        private int thirdSide;

        public Triangle(int firstSide, int secondSide, int thirdSide)
        {
            if (firstSide + secondSide > thirdSide && firstSide + thirdSide > secondSide && secondSide + thirdSide > firstSide)
            {
                this.FirstSide = firstSide;
                this.SecondSide = secondSide;
                this.ThirdSide = thirdSide;
            }
            else
                throw new ArgumentException("This is not a triangle!");
        }

        public int FirstSide
        {
            set
            {
                if (value > 0)
                    this.firstSide = value;
                else
                    throw new ArgumentException("Triangle's side must be above than 0");
            }
            get
            {
                return this.firstSide;
            }
        }

        public int SecondSide
        {
            set
            {
                if (value > 0)
                    this.secondSide = value;
                else
                    throw new ArgumentException("Triangle's side must be above than 0");
            }
            get
            {
                return this.secondSide;
            }
        }

        public int ThirdSide
        {
            set
            {
                if (value > 0)
                    this.thirdSide = value;
                else
                    throw new ArgumentException("Triangle's side must be above than 0");
            }
            get
            {
                return this.thirdSide;
            }
        }

        public int GetPerimeter
        {
            get
            {
                return this.FirstSide + this.SecondSide + this.ThirdSide;
            }
        }

        public double GetArea
        {
            get
            {
                double semiPerimeter = (this.FirstSide + this.SecondSide + this.thirdSide) / 2d;
                return Math.Sqrt(semiPerimeter * (semiPerimeter - this.FirstSide) * (semiPerimeter - this.SecondSide) * (semiPerimeter - this.thirdSide));
            }
        }
    }
}
