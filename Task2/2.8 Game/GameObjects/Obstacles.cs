using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_Game.GameObjects
{
    abstract class Obstacles : IGameObject
    {
        public Box box;
        public bool destroy;

        public abstract void Destroy();
        public abstract bool isDestroyed();
        public abstract void Render();
        public abstract void Update();
    }
}
