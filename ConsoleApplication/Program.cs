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
                game.Field.ZeroField();
                game.Field.SetPosition(StarLord.Body, StarLord.position.X, StarLord.position.Y);

                Draw(game.Field);

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

        public static void Draw(Field field)
        {
            for (int i = 0; i < field.FieldArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < field.FieldArray.Length / (field.FieldArray.GetUpperBound(0) + 1); j++)
                {
                    Console.Write(field.FieldArray[i, j]);
                }

                Console.WriteLine("");
            }
        }
    }

    class Field
    {

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

            return new Field {FieldArray = Pos} ;
        }

        public void ZeroField()
        {
            for (int i = 0; i < FieldArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < FieldArray.Length / (FieldArray.GetUpperBound(0) + 1); j++)
                {
                    FieldArray[i, j] = '.';
                }
            }
        }

        public void SetPosition(char symbol, int X, int Y)
        {
            FieldArray[X, Y] = symbol;
        }
    }

    class Game
    {
        public Field Field { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        
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