namespace SimpleSnake.GameObjects.Foods
{
    using System;
    public class FoodDollar : Food
    {
        private const int DefaultPoints = 5;
        private const char FoodSymbol = '$';
        private const ConsoleColor DefaultColor = ConsoleColor.Green;
        public FoodDollar(Wall wall) : base(wall, DefaultPoints, FoodSymbol, DefaultColor){}
    }
}
