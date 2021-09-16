using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var game = new Game(60, 20, 50, ' ');
            int speed = 1;

            _ = Task.Run(() =>
              {
                  while (true)
                  {
                      var key = Console.ReadKey();
                      switch (key.KeyChar)
                      {
                          case 'a':
                              game.MoveStarship(-1, 0);
                              break;
                          case 'd':
                              game.MoveStarship(1, 0);
                              break;
                          case 'k':
                              game.Shot();
                              break;
                      }
                  }
              });

            while (true)
            {
                game.UpdateField();
                Draw(game.Field);
                game.MoveAlien(speed, 0);
                game.MoveShot(0, -1);
                game.Collision();

                await Task.Delay(1000 / 10);
                Console.Clear();

                if (game.AlienIsDie())
                {
                    Console.Clear();
                    Console.WriteLine("!!!YOU WIN!!!");
                    break;
                }

                if (game.AlienIsWin())
                {
                    Console.Clear();
                    Console.WriteLine("!!!GAME OVER!!!");
                    break;
                }
            }
        }

        private static void Draw(Field field)
        {
            for (var i = 0; i < field.Height; i++)
            {
                Console.Write("|");
                for (var j = 0; j < field.Width; j++) Console.Write(field.FieldArray[i, j]);
                Console.WriteLine("|");
            }
        }
    }
}