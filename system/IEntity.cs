using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.system
{
    internal interface IEntity
    {
        public Vector2i Transform { get; set; }
        public bool isLive { get; set; }
        public void Update(double deltaTime, IGameWorld gameWorld);
    }
}
