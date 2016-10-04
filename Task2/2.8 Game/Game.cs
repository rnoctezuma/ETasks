using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._8_Game.GameObjects;

namespace _2._8_Game
{ 
    public class Game
    {
        public List<IGameObject> GameObjects { get; set; }

        private Player player = null;
        public bool gameover = false;

        public Game() { }

        public bool isDestroyed()
        {
            return true;
        }

        public void Clear()
        {
            this.GameObjects.Clear();
        }
        public void Update()
        {

        }
        public void Render()
        {
        }
        public void Init()
        {
        }
    }
}



