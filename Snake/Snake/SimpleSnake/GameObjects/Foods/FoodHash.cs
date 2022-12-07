using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const int DefaultPoints = 2;
        private const char FoodSymbol = '#';
        private const ConsoleColor DefaultColor = ConsoleColor.DarkMagenta;
        public FoodHash(Wall wall) : base(wall, DefaultPoints, FoodSymbol, DefaultColor){}
    }
}
