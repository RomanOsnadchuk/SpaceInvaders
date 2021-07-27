using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Height = 20;
            game.Width = 50;
            game.Field = Field.InitializeField(game.Height, game.Width);
            Invaider Alien1 = new Invaider();
            Alien1.Body = 'W';
           
            Starship StarLord = new Starship();
            StarLord.Body = 'Д';
            StarLord.position.X = game.Height-1;
            StarLord.position.Y = game.Width/2-1;

            while (true)
            {
                Field.ZeroField(game.Field);
                game.SetPosition(StarLord.Body, StarLord.position.X, StarLord.position.Y);

                Field.DrawField(game.Field);

                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'a':
                        StarLord.position.Move(0, -1);
                        break;
                    case 'd':
                        StarLord.position.Move(0, 1);
                        break;
                }
                Console.Clear();

            }
        }
    }

    class Field
    {
        public static void DrawField(char[,] field)
        {
            for (int i = 0; i < field.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < field.Length/ (field.GetUpperBound(0) + 1); j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine("");
            }
        }

        public static char[,] InitializeField(int height, int width)
        {
            char[,] Pos = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Pos[i, j] = '.';
                }
            }
            return Pos;
        }

        public static void ZeroField(char[,] Field)
        {
            for (int i = 0; i < Field.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Field.Length / (Field.GetUpperBound(0) + 1); j++)
                {
                    Field[i, j] = '.';
                }
            }
        }


    }

    class Game
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Field { get; set; }
        public void SetPosition(char symbol, int X, int Y)
        {
            Field [X,Y] = symbol;
        }
    }

    class Starship
    {
        public char Body { get; set; }
        public Coordynate position = new Coordynate();
        //public int X { get; set; }
       // public int Y { get; set; }

    }

    class Invaider
    {
        public char Body { get; set; }
        public Coordynate position = new Coordynate();
        //public int X { get; set; } 
        //public int Y { get; set; }
    }

    class Coordynate
    {
        public int X { get; set; }
        public int Y { get; set; }
               
        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }
    }

}