namespace TurnBase
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public bool IsAdjacentTo(Point other)
        {
            return (this.X == other.X && this.Y <= other.Y + 1 && this.Y >= other.Y - 1) ||
                   (this.Y == other.Y && this.X <= other.X + 1 && this.X >= other.X - 1);
        }

        public override string ToString()
        {
            return $"({(char)('A' + this.X)}{this.Y})";
        }
    }
}