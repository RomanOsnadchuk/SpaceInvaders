namespace Core
{
    public class Field
    {
        public int Width => FieldArray.Length / Height;
        public int Height => FieldArray.GetUpperBound(0) + 1;
        public char[,] FieldArray { get; set; }

        public static Field InitializeField(int height, int width)
        {
            var pos = new char[height, width];

            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                pos[i, j] = '.';

            return new Field
            {
                FieldArray = pos
            };
        }

        public void ZeroField()
        {
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                FieldArray[i, j] = '.';
        }

        public void Set(GameObject sprite)
        {
            FieldArray[sprite.Position.Y, sprite.Position.X] = (char)sprite.Body;
        }
    }
}