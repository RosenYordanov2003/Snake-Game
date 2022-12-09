namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Wall _wall;
        private readonly int points;
        private readonly char _foodSymbol;
        private readonly ConsoleColor color;
        private Random random;

        protected Food(Wall wall, int points, char foodSymbol, ConsoleColor color) : base(wall.LeftX, wall.TopY)
        {
            Points = points;
            random = new Random();
            this._foodSymbol = foodSymbol;
            this.color = color;
            this._wall = wall;
        }
        public int Points { get; private set; }

        public void SetFoodOnRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this._wall.LeftX - 2);
            this.TopY = this.random.Next(2, this._wall.TopY - 2);

            bool isSnakeElement = snakeElements
                .Any(e => e.LeftX == this.LeftX && e.TopY == this.TopY);
            while (isSnakeElement)
            {
                this.LeftX = this.random.Next(2, this._wall.LeftX - 2);
                this.TopY = this.random.Next(2, this._wall.TopY - 2);

                isSnakeElement = snakeElements
                    .Any(e => e.LeftX == this.LeftX && e.TopY == this.TopY);
            }

            Console.BackgroundColor = this.color;
            this.Draw(this._foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFood(Point snakeNewHead) =>
             snakeNewHead.LeftX == this.LeftX && snakeNewHead.TopY == this.TopY;
    }
}
