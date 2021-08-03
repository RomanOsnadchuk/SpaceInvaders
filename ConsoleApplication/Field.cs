namespace ConsoleApplication
{
    internal class Field
    {
        public int Width => FieldArray.Length / Height;
        public int Height => FieldArray.GetUpperBound(0) + 1;
        public char[,] FieldArray { get; set; }

        public static Field InitializeField(int height, int width)
        {
            var Pos = new char[height, width];

            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                Pos[i, j] = '.';

            return new Field
            {
                FieldArray = Pos
            };
        }

        public void ZeroField()
        {
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                FieldArray[i, j] = '.';
        }

        public void Set(Sprite sprite)
        {
            FieldArray[sprite.Position.Y, sprite.Position.X] = sprite.Body;
        }
    }
}