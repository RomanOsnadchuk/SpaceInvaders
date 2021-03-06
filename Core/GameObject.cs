namespace Core
{
    public class GameObject
    {
        public GameObject(char body, int x, int y)
        {
            Body = body;
            Position = new Coordynate(x, y);
        }

        public char Body { get; set; }
        public Coordynate Position { get; set; }

        public void Move(int deltaX, int deltaY)
        {
            Position.X += deltaX;
            Position.Y += deltaY;
        }
    }
}