namespace Core
{
    public class Field
    {
        public Field(int width, int height, char backGround = '.')
        {
            Width = width;
            Height = height;
            BackGround = backGround;
            FieldArray = new char[Height, Width];
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                FieldArray[i, j] = BackGround;
        }

        public int Width { get; }
        public int Height { get; }
        public char[,] FieldArray { get; }
        public char BackGround { get; }

        public void ZeroField()
        {
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                FieldArray[i, j] = BackGround;
        }

        public void ZeroPosition(GameObject gameObject)
        {
            FieldArray[gameObject.Position.Y, gameObject.Position.X] = BackGround;
        }

        public void Set(GameObject gameObject)
        {
            FieldArray[gameObject.Position.Y, gameObject.Position.X] = gameObject.Body;
        }
    }
}