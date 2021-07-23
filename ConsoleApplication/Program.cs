using System;
using System.Dynamic;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Height = 20;
            game.Width = 50;
            //Console.BufferHeight = 
            //Console.BufferWidth = 
            
            char[,] Pos = new char[game.Height,game.Width];
            for (int i = 0; i < game.Height; i++)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    Pos[i, j] = '.';
                }
            }

            DrawField(game, Pos);
            
            

            Console.ReadLine();
        }

        private static void DrawField(Game game, char[,] Pos)
        {
            for (int i = 0; i < game.Height; i++)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    Console.Write(Pos[i, j]);
                }

                Console.WriteLine("");
            }
        }
    }

    class Game
    {
        public int Width { get; set; }
        public int Height { get; set; }
        
        
    }

    class Starship
    {
        public char Body { get; set; }
        private Coordynate position = new Coordynate();
    }

    class Invaider
    {
        public char Body { get; set; }
        private Coordynate position = new Coordynate();
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