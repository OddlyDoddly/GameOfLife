using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.system.impl.entities
{
    internal class CellEntity : IEntity
    {
        public Vector2i Transform { get; set; }
        public bool isLive { get; set; }

        public CellEntity(Vector2i transform, bool isLive=false)
        {
            this.Transform = transform;
            this.isLive = isLive;
        }

        public void Update(double deltaTime, IGameWorld gameWorld)
        {
            List<IEntity> neighbors = GetNeighbors(gameWorld, this.Transform);

            // Any Cell with fewer than 2 live neighbors dies by underpopulation.
            // Any Cell with greater than 3 live neighbors dies by overpopulation
            if (this.isLive && (neighbors.Count < 2 || neighbors.Count > 3))
            {
                this.isLive=false;
            }

            // Any cell with exactly 3 live neighbors, comes alive by reproduction
            if(!this.isLive && neighbors.Count == 3)
            {
                this.isLive = true;
            }
        }

        private List<IEntity> GetNeighbors(IGameWorld gameWorld, Vector2i transform)
        {
            List<IEntity> neighbors = new List<IEntity>();

            for (int x = transform.X - 1; x <= transform.X + 1; ++x)
            {
                if (x < 0 || x >= gameWorld.WorldSize.X) continue;
                for (int y = transform.Y - 1; y <= transform.Y + 1; ++y)
                {
                    if (y < 0 || y >= gameWorld.WorldSize.Y) continue;
                    if (x == this.Transform.X && y == this.Transform.Y) continue;

                    if (gameWorld.Entities[x, y].isLive)
                    {
                        neighbors.Add(gameWorld.Entities[x, y]);
                    }
                }
            }

            return neighbors;
        }
    }
}
