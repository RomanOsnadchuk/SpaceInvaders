namespace Core
{
    public class Field
    {
        public int Width{get;}
        public int Height{get;}
        public char[,] FieldArray { get;}
        private char Fond {get;}

        public Field(int width, int height, char fond = '.')
        {
            Width = width;
            Height = height;
            FieldArray = new char[width,height];
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                FieldArray[i, j] = fond;
        }
        public void ZeroField()
        {
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                FieldArray[i, j] = Fond;
        }
        public void Set(GameObject gameObject)
        {
            FieldArray[gameObject.Position.Y, gameObject.Position.X] = gameObject.Body;
        }
    }
}