using System;
using System.Threading;
using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private const double DefaultSleepTime = 100;
        private Point[] _points;
        private Direction _direction;
        private Snake _snake;
        private Wall _wall;
        private double _sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            _points = new Point[4];
            _snake = snake;
            _wall = wall;
            this._sleepTime = DefaultSleepTime;
        }
        public void Run()
        {
            this.CreateDirections();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this._snake.IsMoving(this._points[(int)this._direction]);
                if (!isMoving)
                {
                    //Todo
                }

                this._sleepTime -= 0.01;
                Thread.Sleep((int)this._sleepTime);
            }
        }

        private void CreateDirections()
        {
            this._points[(int)Direction.Right] = new Point(1, 0);
            this._points[(int)Direction.Left] = new Point(-1, 0);
            this._points[(int)Direction.Down] = new Point(0, 1);
            this._points[(int)Direction.Up] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key==ConsoleKey.LeftArrow)
            {
                if (this._direction!=Direction.Right)
                {
                    this._direction = Direction.Left;
                }
            }
            else if (userInput.Key==ConsoleKey.RightArrow)
            {
                if (_direction!=Direction.Right)
                {
                    this._direction = Direction.Right;
                }
            }
            else if (userInput.Key==ConsoleKey.UpArrow)
            {
                if (this._direction!=Direction.Down)
                {
                    this._direction = Direction.Up;
                }
            }
            else if(userInput.Key==ConsoleKey.DownArrow)
            {
                if (this._direction!=Direction.Up)
                {
                    this._direction = Direction.Down;
                }
            }
            Console.CursorVisible = false;
        }
    }
}
