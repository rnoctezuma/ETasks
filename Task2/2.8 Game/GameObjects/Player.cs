using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_Game.GameObjects
{
    class Player : IGameObject, IMoveble
    {
        public Box box;
        public int health;
        public bool destroy = false;
        public int score = 0;

        public void Damage()
        {
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public bool isDestroyed()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
