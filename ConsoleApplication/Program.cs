using System;
using System.Threading.Tasks;
using Core;
using Repository;

namespace ConsoleApplication
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var repository = new FileRepository();
            var game = repository.LoadGame() ?? new Game(60, 20, 20, ' ');
            var speed = 1;

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
                        case 'y':
                            repository.SaveGame(game);
                            break;
                    }
                }
            });

            while (true)
            {
                Console.Clear();
                //game.UpdateField();
                Draw(game.Field);
                game.MoveAliens(speed, 0);
                game.MoveShot(0, -1);
                game.Collision();

                await Task.Delay(1000 / 20);

                if (game.AliensIsDie())
                {
                    Console.Clear();
                    Console.WriteLine("!!!YOU WIN!!!");
                    Console.ReadLine();
                    break;
                }

                if (game.AliensIsWin())
                {
                    Console.Clear();
                    Console.WriteLine("!!!GAME OVER!!!");
                    Console.ReadLine();
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