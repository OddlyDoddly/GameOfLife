using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.system
{
    internal interface IGameWorld
    {
        public Vector2i WorldSize { get; set; }
        public IEntity[,] Entities { get; set; }
        public void Update(double deltaTime);
        public bool EntityExistsAtPos(Vector2i transform);
    }
}
