using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class uses the C# console as a screen for the game world.
namespace GameOfLife.system.impl
{
    internal class ConsoleScreen : IGameScreen
    {
        public Vector2i ScreenPosition { get; set; }
        public Vector2i ScreenSize { get; set; }
        public static char[,] EmptyConsoleBuffer;
        public static char[,] CurrentConsoleBuffer;
        public static string ConsoleString;

        public ConsoleScreen(Vector2i screenPosition, Vector2i screenSize)
        {
            Console.SetBufferSize(screenSize.X, screenSize.Y);
            EmptyConsoleBuffer = new char[screenSize.X, screenSize.Y];
            CurrentConsoleBuffer = new char[screenSize.X, screenSize.Y];

            for (int x = 0; x < EmptyConsoleBuffer.GetLength(0); x++)
            {
                for(int y = 0; y < EmptyConsoleBuffer.GetLength(1); y++)
                {
                    EmptyConsoleBuffer[x, y] = ' ';
                    CurrentConsoleBuffer[x, y] = ' ';
                }
            }

            ScreenPosition = screenPosition;
            ScreenSize = screenSize;
        }

        private char[,] GetWorldScreenBuffer(IGameWorld gameWorld, Vector2i pos, Vector2i size)
        {
            char[,] screenBuffer = EmptyConsoleBuffer;

            for (int x = pos.X; x < pos.X + size.X; ++x)
            {
                for (int y = pos.Y; y < pos.Y + size.Y; ++y)
                {
                    if (gameWorld.Entities[x, y].isLive)
                    {
                        screenBuffer[x, y] = '█';
                    } else
                    {
                        screenBuffer[x, y] = ' ';
                    }
                }
            }

            return screenBuffer;
        }

        public void Draw(double deltaTime, IGameWorld gameWorld)
        {
            Array.Copy(EmptyConsoleBuffer, CurrentConsoleBuffer, EmptyConsoleBuffer.Length);

            CurrentConsoleBuffer = GetWorldScreenBuffer(gameWorld, ScreenPosition, ScreenSize);

            ConsoleString = "";
            for (int iy = 0; iy < Console.BufferHeight - 1; iy++)
            {
                for (int ix = 0; ix < Console.BufferWidth; ix++)
                {
                    ConsoleString += CurrentConsoleBuffer[ix, iy];
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(ConsoleString);
        }
    }
}
