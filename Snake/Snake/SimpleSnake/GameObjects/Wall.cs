namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            InitializeHorizontalAndVerticalLines();
        }
        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.TopY == 0 || snakeHead.LeftX == 0 || snakeHead.LeftX == this.LeftX - 1 ||
                   snakeHead.TopY == this.TopY;
        }
        private void InitializeHorizontalAndVerticalLines()
        {
            DrawHorizontalLine(0);
            DrawHorizontalLine(TopY);
            Draw_VerticalLine(0);
            Draw_VerticalLine(LeftX - 1);
        }
        private void DrawHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        private void Draw_VerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }
    }
}
