using System;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Field = Field.InitializeField(10, 50);
            var Alien1 = new Sprite();
            game.Alien = Alien1;
            Alien1.Body = 'W';
            Alien1.Position.Y = 0;
            Alien1.Position.X = game.Field.Width / 2 - 1;

            Sprite StarLord = new Sprite();
            game.Starship = StarLord;
            StarLord.Body = 'Д';
            StarLord.Position.Y = game.Field.Height - 1;
            StarLord.Position.X = game.Field.Width / 2 - 1;


            while (true)
            {
                game.Field.ZeroField();
                game.Field.Set(StarLord);
                game.Field.Set(Alien1);
                foreach (var i in game.Bullet)
                {
                    if (i != null)
                        game.Field.Set(i);
                }
                

                Draw(game.Field);

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
                game.MoveAlien(1, 0);
                game.MoveShot(0, -1);

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
}