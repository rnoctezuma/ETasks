using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_Game.GameObjects
{
    public abstract class Enemy : IGameObject, IMoveble
    {
        public Box Box { get; set; }
        public int health { get; set; }
        public bool destroy { get; set; }

        public abstract void Damage();
        public abstract void Destroy();
        public abstract bool isDestroyed();
        public abstract void Move();
        public abstract void Render();
        public abstract void Update();
    }
}