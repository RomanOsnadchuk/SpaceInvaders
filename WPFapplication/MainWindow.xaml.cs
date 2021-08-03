using System;
using System.Windows;
using Core;

namespace WPFapplication
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var game = new Game {Field = Field.InitializeField(30, 50)};
            var alien1 = new Sprite();
            game.Alien = alien1;
            alien1.Body = 'W';
            alien1.Position.Y = 0;
            alien1.Position.X = game.Field.Width / 2 - 1;

            var starLord = new Sprite();
            game.Starship = starLord;
            starLord.Body = 'Д';
            starLord.Position.Y = game.Field.Height - 1;
            starLord.Position.X = game.Field.Width / 2 - 1;


            while (true)
            {
                game.Field.ZeroField();
                game.Field.Set(starLord);
                game.Field.Set(alien1);
                foreach (var i in game.Bullet)
                    if (i != null)
                        game.Field.Set(i);


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
                game.Colision();
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