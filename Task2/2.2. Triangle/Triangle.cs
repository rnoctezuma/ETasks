using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.Triangle
{
    public class Triangle
    {
        private int firstSide { get; set; }
        private int secondSide { get; set; }
        private int thirdSide { get; set; }

        public Triangle(int firstSide, int secondSide, int thirdSide)
        {
            if (this.Validate(firstSide, secondSide, thirdSide))
            {
                this.firstSide = firstSide;
                this.secondSide = secondSide;
                this.thirdSide = thirdSide;
            }
            else
                throw new ArgumentException("This is not a triangle!");
        }

        public int FirstSide
        {
            get { return this.firstSide; }
            set
            {
                if (!this.Validate(value, secondSide, thirdSide))
                    throw new ArgumentException("A new side value incorrect");
                this.firstSide = value;
            }
        }

        public int SecondSide
        {
            get { return this.secondSide; }
            set
            {
                if (!this.Validate(firstSide, value, thirdSide))
                    throw new ArgumentException("A new side value incorrect");
                this.secondSide = value;
            }
        }

        public int ThirdSide
        {
            get { return this.thirdSide; }
            set
            {
                if (!this.Validate(firstSide, secondSide, value))
                    throw new ArgumentException("A new side value incorrect");
                this.thirdSide = value;
            }
        }

        //сделать валидацию треугольника в методе после того как его создал

        private bool Validate(int firstSide, int secondSide, int thirdSide)
        {
            if (firstSide + secondSide > thirdSide && firstSide + thirdSide > secondSide && secondSide + thirdSide > firstSide)
                return true;
            return false;
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
                double semiPerimeter = (this.FirstSide + this.SecondSide + this.ThirdSide) / 2d;
                return Math.Sqrt(semiPerimeter * (semiPerimeter - this.FirstSide) * (semiPerimeter - this.SecondSide) *
                    (semiPerimeter - this.ThirdSide));
            }
        }
    }
}
