namespace Core
{
    public class GameObject
    {
        int directionAxis = 0;
        public object Body { get; set; }
        public Coordynate Position { get; set; }

        public GameObject(object body, int x, int y, int direction)
        {
            Body = body;
            Position = new Coordynate(x, y);
            directionAxis = direction;
        }
    }
}