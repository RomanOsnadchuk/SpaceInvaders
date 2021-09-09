namespace Core
{
    public class Sprite<T>
    {
        enum direction
        {
            right = 1,
            invert = -1
        }
        int directionAxis = 0;
        public T Body { get; set; }
        public Coordynate Position { get; set; }

        public Sprite(T body, int x, int y, int directionAxis = (int)direction.right)
        {
            Body = body;
            Position = new Coordynate(x, y);
            this.directionAxis = directionAxis;
        }
    }
}