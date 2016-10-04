using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_Game
{
    public interface IGameObject
    {
        bool isDestroyed();
        void Destroy();
        void Update();
        void Render();
    }
}
