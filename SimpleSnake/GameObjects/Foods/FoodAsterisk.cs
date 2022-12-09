using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const int DefaultPoints = 1;
        private const char FoodSymbol = '*';
        private const ConsoleColor DefaultColor = ConsoleColor.Red; 
        public FoodAsterisk(Wall wall) : base(wall, DefaultPoints, FoodSymbol, DefaultColor){}
    }
}
