using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using Core;
using Repository;

namespace ConsoleApplication
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            bool run;
            var repository = new FileRepository();

            while (true)
            {
                run = false;
                Game game = new Game(30, 10, 20, '.'); 
                var speed = 1;

                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Start New Game");
                Console.WriteLine("2) Load Game");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");
                var a = Console.ReadLine();

                switch (a)
                {
                    case "1":
                        run = true;
                        break;
                    case "2":
                        game = repository.LoadGame() ?? game;
                        run = true;
                        break;
                    case "3":
                        return;
                }

                _ = Task.Run(() =>
                {
                    while (run)
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
                            case 'e':
                                run = false;
                                break;
                        }
                    }
                });

                while (run)
                {
                    Console.Clear();
                    //game.UpdateField();
                    game.MoveShot(0, -1);
                    game.MoveAliens(speed, 0);
                    
                    game.Collision();
                    Draw(game.Field);

                    await Task.Delay(1000 / 5);

                    if (game.AliensIsDie())
                    {
                        run = false;
                        Console.Clear();
                        Console.WriteLine("!!!YOU WIN!!!");
                        Console.ReadLine();
                        break;
                    }

                    if (game.AliensIsWin())
                    {
                        run = false;
                        Console.Clear();
                        Console.WriteLine("!!!GAME OVER!!!");
                        Console.ReadLine();
                        break;
                    }
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