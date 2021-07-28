namespace ConsoleApplication
{
    class Coordynate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator == (Coordynate c1, Coordynate c2)
        {
            return c1.X == c2.X && c1.Y == c2.Y;
        }
        public static bool operator !=(Coordynate c1, Coordynate c2)
        {
            return c1.X != c2.X || c1.Y != c2.Y;
        }
    }
}