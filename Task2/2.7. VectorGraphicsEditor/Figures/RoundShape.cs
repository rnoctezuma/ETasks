using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    class RoundShape : IFigure
    {
        private double radius;

        public RoundShape(double radius)
        {
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

        public double GetLength
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public double GetArea      //1) protected и обернуть в public? 2) убрать из интерфейса 3) изменить наследование? 4) virtual?
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }

        public virtual string Draw()
        {
            return "";
        }
    }
}
