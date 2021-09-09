namespace Core
{
    public class Sprite<T>
    {
        int directionAxis = 0;
        public T Body { get; set; }
        public Coordynate Position { get; set; }

        public Sprite(T body, int x, int y, int direction)
        {
            Body = body;
            Position = new Coordynate(x, y);
            directionAxis = direction;
        }
    }
}