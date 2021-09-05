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
        int dropSpeed = 10;
        bool goLeft, goRight, Shot, InvaderLive = true;
        List<Rectangle> Bullets = new List<Rectangle>();

        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
           

            if (goLeft == true && Canvas.GetLeft(starship) > 0)
            {
                Canvas.SetLeft(starship, Canvas.GetLeft(starship) - speed);
            }
            if (goRight == true && Canvas.GetLeft(starship) + (starship.Width + 24) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(starship, Canvas.GetLeft(starship) + speed);
            }

            if (Shot == true)
            {
                Fire();
            }
            if (InvaderLive)
            {
                if (Canvas.GetLeft(invaider) + invaider.Width + 50 < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(invaider, Canvas.GetLeft(invaider) + speed);
                }
                else
                {
                    Canvas.SetLeft(invaider, 10);
                    Canvas.SetTop(invaider, Canvas.GetTop(invaider) + invaider.Height);
                }
            }
            else 
            {
                invaider.Fill = Brushes.Gray;
            }

            if (Bullets != null)
            {
                for (int i = 0; i < Bullets.Count; i++)
                {
                    Canvas.SetTop(Bullets[i], Canvas.GetTop(Bullets[i]) - 30);
                    if (Canvas.GetTop(Bullets[i]) < 20) myCanvas.Children.Remove(Bullets[i]);
                    if ((Canvas.GetLeft(Bullets[i]) > Canvas.GetLeft(invaider)) && (Canvas.GetLeft(Bullets[i]) < Canvas.GetLeft(invaider) + invaider.Width) && (Canvas.GetTop(Bullets[i]) > Canvas.GetTop(invaider)) && (Canvas.GetTop(Bullets[i]) < Canvas.GetTop(invaider) + invaider.Height)) DieInvaider();
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
                Fire();
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
                Shot = false;
            }
        }

        private void DieInvaider()
        {
            // invaider.Visibility = Visibility.Hidden;
            //myCanvas.Children.Remove(invaider);
            InvaderLive = false;
            win.Visibility = Visibility.Visible;
        }

        private void Fire()
        {
            //Rectangle NewRect = new Rectangle { Height = bullet.Height, Width = bullet.Width, Fill = Brushes.Blue, Visibility = Visibility.Visible };
            //Canvas.SetLeft(NewRect, Canvas.GetLeft(starship));
            //Canvas.SetTop(NewRect, Canvas.GetTop(starship));
            Bullets.Add(new Rectangle { Height = bullet.Height, Width = bullet.Width, Fill = Brushes.Blue });
            Canvas.SetLeft(Bullets[Bullets.Count - 1], Canvas.GetLeft(starship));
            Canvas.SetTop(Bullets[Bullets.Count - 1], Canvas.GetTop(starship));
            myCanvas.Children.Add(Bullets[Bullets.Count-1]);
        }
       
    }
}