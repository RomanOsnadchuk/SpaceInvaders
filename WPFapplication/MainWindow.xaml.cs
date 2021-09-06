using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using Core;

namespace WPFapplication
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        int speed = 10;
        bool start = true, goLeft, goRight, Shot, InvaderLive = true;
        List<Rectangle> Bullets = new List<Rectangle>();
        List<Rectangle> Invaiders = new List<Rectangle>();

        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(20);

            if (start) timer.Start();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (InvaderLive)
            {
                MoveOnPress(starship, speed);
                if (Canvas.GetLeft(invaider) + invaider.Width + 50 < Application.Current.MainWindow.Width)
                {
                    InvaidersAtacks();
                }
                else
                {
                    Canvas.SetLeft(invaider, 2);
                    Canvas.SetTop(invaider, Canvas.GetTop(invaider) + invaider.Height);
                }
            }
            else 
            {
                invaider.Fill = Brushes.Gray;
            }

            if (Bullets != null && Bullets.Count != 0)
            {
                for (int i = 0; i < Bullets.Count; i++)
                {
                    Canvas.SetTop(Bullets[i], Canvas.GetTop(Bullets[i]) - 10);
                    if (Colision(Bullets[i], invaider)) { DieInvaider(); myCanvas.Children.Remove(Bullets[i]);  Bullets.RemoveAt(i); break; }
                    if (Canvas.GetTop(Bullets[i]) < 20) { myCanvas.Children.Remove(Bullets[i]);  Bullets.RemoveAt(i); }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;
            }
            if (e.Key == Key.Space)
            {
                if (Shot) Fire();
                Shot = false;
            }
            if (e.Key == Key.Enter)
            {
                start = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
            }
            if (e.Key == Key.Space)
            {
                Shot = true;
            }
        }

        private void DieInvaider()
        {
            InvaderLive = false;
            win.Visibility = Visibility.Visible;
        }

        private void Fire()
        {
            Bullets.Add(new Rectangle { Height = bullet.Height, Width = bullet.Width, Fill = Brushes.Blue });
            Canvas.SetLeft(Bullets[Bullets.Count - 1], Canvas.GetLeft(starship));
            Canvas.SetTop(Bullets[Bullets.Count - 1], Canvas.GetTop(starship));
            myCanvas.Children.Add(Bullets[Bullets.Count-1]);
        }
       
        private void MoveOnPress(Rectangle ship, int speed)
        {
            if (goLeft == true && Canvas.GetLeft(ship) > 0)
            {
                Canvas.SetLeft(starship, Canvas.GetLeft(ship) - speed);
            }
            if (goRight == true && Canvas.GetLeft(ship) + (ship.Width + 24) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(starship, Canvas.GetLeft(ship) + speed);
            }
        }

        private void InvaidersAtacks()
        {
            Canvas.SetLeft(invaider, Canvas.GetLeft(invaider) + speed);
        }

        private bool Colision(Rectangle Body1, Rectangle Body2)
        {
            return (Canvas.GetLeft(Body1) > Canvas.GetLeft(Body2))
                && (Canvas.GetLeft(Body1) < Canvas.GetLeft(Body2) + Body2.Width)
                && (Canvas.GetTop(Body1) > Canvas.GetTop(Body2))
                && (Canvas.GetTop(Body1) < Canvas.GetTop(Body2) + Body2.Height);
        }
    }
}