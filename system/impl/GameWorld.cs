using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.system.impl.entities;

namespace GameOfLife.system.impl
{
    internal class GameWorld : IGameWorld
    {
        //public List<List<IEntity>> Entities { get; set; }
        public IEntity[,] Entities { get; set; }
        public Vector2i WorldSize { get; set; }

        public GameWorld(Vector2i worldSize)
        {
            WorldSize = worldSize;
            InitializeWorld(worldSize);
            InitializeCells(worldSize);
        }

        public void ResizeWorld(Vector2i worldSize) {
            IEntity[,] newWorld = new IEntity[worldSize.X, worldSize.Y];

            // Copy over old entities, or create new empty ones.
            for(int x = 0; x < worldSize.X; ++x)
            {
                for ( int y = 0; y < worldSize.Y; ++y)
                {
                    if(x < WorldSize.X && y < WorldSize.Y) {
                        newWorld[x, y] = Entities[x, y];
                    } else {
                        newWorld[x, y] = new CellEntity(new Vector2i(x, y), false);
                    }
                }
            }

            Entities = newWorld;
            WorldSize = worldSize;
        }

        private void InitializeCells(Vector2i worldSize)
        {
            Random r = new Random();
            for (int x = 0; x < worldSize.X; x++)
            {
                for (int y = 0; y < worldSize.Y; y++)
                {
                    if (r.Next(8) == 0)
                    {
                        Entities[x, y].isLive = true;
                    }
                }
            }
        }

        private void InitializeWorld(Vector2i worldSize)
        {
            Entities = new IEntity[worldSize.X, worldSize.Y];
            for(int x = 0; x < worldSize.X; ++x)
            {
                for ( int y = 0; y < worldSize.Y; ++y)
                {
                    Entities[x, y] = new CellEntity(new Vector2i(x, y), false);
                }
            }
        }

        public bool EntityExistsAtPos(Vector2i transform)
        {
            return Entities[transform.X, transform.Y].isLive;
        }

        public void Update(double deltaTime)
        {
            for(int x = 0; x < WorldSize.X; ++x)
            {
                for(int y = 0; y < WorldSize.Y; ++y)
                {
                    Entities[x, y].Update(deltaTime, this);
                }
            }
        }
    }
}
