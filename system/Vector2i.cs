using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.system
{
    internal class Vector2i
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public Vector2i(int x, int y)
        {
            X = x; 
            Y = y; 
        }

        public static Vector2i operator +(Vector2i v1, Vector2i v2)
        {
            return new Vector2i(v1.X + v2.X, v1.Y + v2.Y); 
        }

        public static Vector2i operator -(Vector2i v1, Vector2i v2)
        {
            return new Vector2i(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2i operator /(Vector2i v1, Vector2i v2)
        {
            return new Vector2i(v1.X / v2.X, v1.Y / v2.Y);
        }

        public static Vector2i operator /(Vector2i v1, int scalar)
        {
            return new Vector2i(v1.X * scalar, v1.Y * scalar);
        }

        public static Vector2i operator *(Vector2i v1, Vector2i v2)
        {
            return new Vector2i(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2i operator *(Vector2i v1, int scalar)
        {
            return new Vector2i(v1.X * scalar, v1.Y * scalar);
        }

        public Vector2i GetDistance(Vector2i v2)
        {
            return new Vector2i(this.X - v2.X, this.Y - v2.Y);
        }

        public float GetNormalDistance(Vector2i v2)
        {
            return (float)Math.Sqrt(Math.Pow(X - v2.X, 2) + Math.Pow(Y - v2.Y, 2));
        }

        public bool IsWithin(Vector2i pos, Vector2i size)
        {
            return X > pos.X && 
                X < pos.X + size.X && 
                Y > pos.Y && 
                Y < pos.Y + size.Y;
        }
    }
}
