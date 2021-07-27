using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Field = Field.InitializeField(20, 50);
            var Alien1 = new Starship();
            Alien1.Body = 'W';

            Starship StarLord = new Starship();
            StarLord.Body = 'Д';
            StarLord.Position.X = game.Field.Height - 1;
            StarLord.Position.Y = game.Field.Width / 2 - 1;

            while (true)
            {
                game.Field.ZeroField();
                game.Field.Set(StarLord.Body, StarLord.Position);

                Draw(game.Field);

                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case 'a':
                        StarLord.Move(0, -1);
                        break;
                    case 'd':
                        StarLord.Move(0, 1);
                        break;
                }
                Console.Clear();

            }
        }

        public static void Draw(Field field)
        {
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    Console.Write(field.FieldArray[i, j]);
                }

                Console.WriteLine("");
            }
        }
    }

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

        public void Set(char symbol, Coordynate coordynate)
        {
            FieldArray[coordynate.X, coordynate.Y] = symbol;
        }
    }

    class Game
    {
        public Field Field { get; set; }



    }

    class Starship
    {
        public char Body { get; set; }
        public Coordynate Position { get; set; } = new Coordynate();

        public void Move(int deltaX, int deltaY)
        {
            Position.X += deltaX;
            Position.Y += deltaY;
        }

    }

    class Coordynate
    {
        public int X { get; set; }
        public int Y { get; set; }


    }

}