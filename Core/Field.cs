using System;

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
            ZeroArray = new char[Height, Width];
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                ZeroArray[i, j] = BackGround;
        }

        public int Width { get; }
        public int Height { get; }
        public char[,] FieldArray { get; set; }
        private char[,] ZeroArray { get; }
        public char BackGround { get; }

        public void ZeroField()
        {
            Array.Copy(ZeroArray,FieldArray,ZeroArray.Length);
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