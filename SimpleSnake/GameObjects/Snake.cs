using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int InitialSnakeLength = 6;
        private const char SnakeSymbol = '\u25CF';
        private readonly Queue<Point> snakeElements;
        private readonly List<Food> foods;
        private readonly Wall wall;
        private int nextLeftX;
        private int nextLeftTopY;
        private int foodIndex;
        private Random random;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new List<Food>();
            random = new Random();
            this.foodIndex = RandomNumber;
            this.GetFoods();
            CreateSnake();
        }

        private int RandomNumber
        {
            get=>random.Next(0,this.foods.Count);
        }
        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);
            //check wheter snake has bitten himself
            bool isPointOfSnake = this.snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextLeftTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextLeftTopY);
            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }
            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);
            if (this.foods[foodIndex].IsFood(snakeNewHead))
            {
                this.Eat(direction, snakeNewHead);
            }
            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= InitialSnakeLength; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            foods.Add(new FoodAsterisk(this.wall));
            foods.Add(new FoodDollar(this.wall));
            foods.Add(new FoodHash(this.wall));
            SpawnFood();
        }

        private void GetNextPoint(Point point, Point head)
        {
            this.nextLeftX = head.LeftX + point.LeftX;
            this.nextLeftTopY = head.TopY + point.TopY;
        }

        private void Eat(Point direction, Point snakeHead)
        {
            int snakeLengthToAdd = this.foods[foodIndex].Points;
            for (int i = 0; i < snakeLengthToAdd; i++)
            {
                this.snakeElements.Enqueue(new Point(nextLeftX,nextLeftTopY));
                GetNextPoint(direction,snakeHead);
            }
            SpawnFood();
        }

        public void SpawnFood()
        {
            this.foodIndex = RandomNumber;
            this.foods[foodIndex].SetFoodOnRandomPosition(this.snakeElements);
        }
    }
}
