﻿using SimpleSnake.Core;
using SimpleSnake.Core.Contracts;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);
            IEngine engine = new Engine(wall,snake);
            engine.Run();
        }
    }
}
