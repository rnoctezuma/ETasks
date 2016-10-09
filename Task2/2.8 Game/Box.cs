using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_Game
{
    public class Box
    {
        public List<Box> colliders = new List<Box>();
        public double x; //  координаты центра объекта
        public double y; //
        public double Width; //полувысота
        public double Height; //полуширина
        public double vx;
        public double vy;
        public bool Static;
        public bool destroy = false;

        public Box() { }

        public bool Collides()
        {
            return true;
        }

        public void Collide()
        {
        }

        public void Update()
        {
        }

        public void Render()
        {
        }
    }
}
