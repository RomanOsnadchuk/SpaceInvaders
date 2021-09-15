using Core;
using System;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var game = new Game(60, 60, 10, ' ');

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
                game.Field.ZeroField();
                game.Field.Set(game.Starship);
                foreach (var alien in game.Alien)
                {
                    game.Field.Set(alien);
                }
                foreach (var i in game.Bullet)
                    if (i != null)
                        game.Field.Set(i);

                Draw(game.Field);

                game.MoveAlien(1, 0);
                game.MoveShot(0, -1);
                game.Collision();

                await Task.Delay(1000 / 12);
                Console.Clear();
                if (game.Alien == null)
                {
                    Console.WriteLine("!!!YOU WIN!!!");
                    break;
                }
            }
        }

        private static void Draw(Field field)
        {
            for (var i = 0; i < field.Height; i++)
            {
                for (var j = 0; j < field.Width; j++) Console.Write(field.FieldArray[i, j]);

                Console.WriteLine("");
            }
        }
    }
}