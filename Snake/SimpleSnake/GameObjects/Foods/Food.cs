namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly int points;
        private readonly char foodSymbol;
        private readonly ConsoleColor color;
        private Random random;
        protected Food(Wall wall, int points, char foodSymbol, ConsoleColor color) : base(wall.LeftX, wall.TopY)
        {
            Points = points;
            random = new Random();
            this.foodSymbol = foodSymbol;
            this.color = color;
            this.wall = wall;
        }

        public int Points { get; private set; }

        public void SetFoodOnRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, LeftX - 2);
            TopY = random.Next(2, TopY - 2);
            bool isSnakePosition = snakeElements.Any(s => s.LeftX == LeftX && s.TopY == TopY);
            while (isSnakePosition)
            {
                LeftX = random.Next(2, LeftX - 1);
                TopY = random.Next(2, TopY - 1);
                isSnakePosition = snakeElements.Any(s => s.LeftX == LeftX && s.TopY == TopY);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFood(Point snakeHead)
        {
            return snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;
        }
    }
}
