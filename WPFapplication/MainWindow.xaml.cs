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
        private List<Rectangle> winBullets;
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

            game = new Game(10, 30, 5, ' ');
            winAlient = new List<Ellipse>();
            winBullets = new List<Rectangle>();

            for (int i = 0; i < game.Aliens.Count; i++)
            {
                winAlient.Add(new Ellipse() { Height = 29, Width = 70, Fill = Brushes.Red, Visibility = Visibility.Visible, IsEnabled = true});
                myCanvas.Children.Add(winAlient[i]);
            }

            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(1000 / 10 );
            timer.Start();
        }


        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (StartGame)
            {
                if (Start.Visibility != Visibility.Hidden) Start.Visibility = Visibility.Hidden;

                game.MoveAliens(1, 0);
                game.MoveShot(0, -1);
                var hit = game.Collision();

                if (hit != null)
                {
                    myCanvas.Children.Remove(winAlient[hit[0]]);
                    myCanvas.Children.Remove(winBullets[hit[1]]);

                    winAlient.RemoveAt(hit[0]);
                    winBullets.RemoveAt(hit[1]);
                }

                UpdatePos(SS, game.Starship);
                UpdatePosAliens();
                UpdatePosBullet();

            }

            void UpdatePos(Shape shape, GameObject gObject)
            {
                double gameBorder = 50;
                Canvas.SetLeft(shape, CalcPos(gameWindow.ActualWidth, game.Field.Width, gObject.Position.X, shape.Width));
                Canvas.SetTop(shape, CalcPos(gameWindow.ActualHeight, game.Field.Height, gObject.Position.Y, shape.Height));

                double CalcPos(double win, double field, double pos, double shape)
                {
                    return gameBorder + (win - 2 * gameBorder) / field * pos + (win - 2 * gameBorder) / (2 * field) - shape / 2;
                }
            }

            void UpdatePosAliens()
            {
                for (int i = 0; i < game.Aliens.Count; i++)
                {
                    UpdatePos(winAlient[i], game.Aliens[i]);
                }

            }

            void UpdatePosBullet()
            {
                for (int i = 0; i < game.Bullets.Count; i++)
                {
                    UpdatePos(winBullets[i], game.Bullets[i]);
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
                    if (readyShot)
                    {
                        game.Shot();
                        winBullets.Add(new Rectangle{ Width = 8, Height = 32, Fill= Brushes.Yellow });
                        myCanvas.Children.Add(winBullets[winBullets.Count - 1]);
                    }
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