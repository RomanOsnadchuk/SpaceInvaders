using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Core;

namespace WPFapplication
{
    public partial class MainWindow : Window
    {
        private readonly Game game;
        private List<Ellipse> winAlient;
        private readonly DispatcherTimer timer = new DispatcherTimer();
        //private bool InvaderLive = true;
        //private bool invaiderDir = true;
        private bool readyShot;

        //private int speed = 10;
        private bool StartGame;

        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();

            game = new Game(20, 20, 2, ' ');
            winAlient = new List<Ellipse>();

            for (int i = 0; i < 2; i++)
            {
                winAlient.Add(new System.Windows.Shapes.Ellipse() { Height = 29, Width = 14, Fill = Brushes.Red, Visibility = Visibility.Visible, IsEnabled = true});
            }

            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(1000 / 10);
            timer.Start();
        }


        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (StartGame)
            {
                if (Start.Visibility != Visibility.Hidden) Start.Visibility = Visibility.Hidden;
                UpdatePos(SS, game.Starship);


                for (int i = 0; i < game.Aliens.Count; i++)
                {
                    UpdatePos(winAlient[i], game.Aliens[i]);
                }
                game.MoveAliens(1, 0);
                game.MoveShot(0, -1);
                game.Collision();
            }

            void UpdatePos(System.Windows.Shapes.Shape shape, GameObject gObject)
            {
                double gameBorder = 50;
                Canvas.SetLeft(shape, calcMidl(gameWindow.ActualWidth, game.Field.Width, gObject.Position.X, shape.Width));
                Canvas.SetTop(shape, calcMidl(gameWindow.ActualHeight, game.Field.Height, gObject.Position.Y, shape.Height));

                double calcMidl(double win, double field, double pos, double shape)
                {
                    return gameBorder + (win - 2 * gameBorder) / field * pos + (win - 2 * gameBorder) / (2 * field) - shape / 2;
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    game.MoveStarship(-1, 0);
                    break;
                case Key.Right:
                    game.MoveStarship(1, 0);
                    break;
                case Key.Space:
                    if (readyShot) game.Shot();
                    readyShot = false;
                    break;
                case Key.Enter:
                    StartGame = true;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: break;
                case Key.Right: break;
                case Key.Space:
                    readyShot = true;
                    break;
            }
        }

        //private void DrawField(Field field)
        //{
        //    var winHeight = gameWindow.ActualHeight;
        //    var winWidth = gameWindow.ActualWidth;
        //
        //    Canvas.SetLeft(SS, 50 + (winWidth - 50)/field.Width * );
        //}
    }
}