using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Field
    {
        public int Width => FieldArray.Length / Height;
        public int Height => FieldArray.GetUpperBound(0) + 1;
        public char[,] FieldArray { get; set; }

        public static Field InitializeField(int height, int width)
        {
            char[,] Pos = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Pos[i, j] = '.';
                }
            }

            return new Field
            {
                FieldArray = Pos,
            };
        }

        public void ZeroField()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    FieldArray[i, j] = '.';
                }
            }
        }

        public void Set(Sprite sprite)
        {
            FieldArray[sprite.Position.Y, sprite.Position.X] = sprite.Body;
        }
    }
}
