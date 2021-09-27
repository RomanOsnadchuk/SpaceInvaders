namespace Repository
{
    internal class GameObjectModel
    {
        public GameObjectModel()
        {
        }

        public GameObjectModel(char body, int x, int y)
        {
            Body = body;
            X = x;
            Y = y;
        }

        public char Body { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}