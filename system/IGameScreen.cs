using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.system
{
    internal interface IGameScreen
    {
        public Vector2i ScreenPosition { get; set; }
        public Vector2i ScreenSize { get; set; }
        public void Draw(double deltaTime, IGameWorld gameWorld);
    }
}
