﻿using System;
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
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        int millisecGame = 0;
        int speed = 10;
        bool goLeft, goRight, Shot, StartGame, invaiderDir = true, InvaderLive = true;
        List<Rectangle> Bullets = new List<Rectangle>();
        List<Rectangle> Invaiders = new List<Rectangle>();

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
            if (StartGame)
            {
                Start.Visibility = Visibility.Hidden;

                if (InvaderLive)
                {
                    StarshipGoGo();
                    InvaidersAtacks();
                    millisecGame += 20;
                }
                
                var tmp = TimeSpan.FromMilliseconds(millisecGame);
                timerbox.Text = "Time = " + tmp.ToString();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: goLeft = true; break;
                case Key.Right: goRight = true; break;
                case Key.Space: if (Shot) Fire(); Shot = false; break;
                case Key.Enter: StartGame = true; break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: goLeft = false; break;
                case Key.Right: goRight = false; break;
                case Key.Space: if (Shot) Fire(); Shot = true; break;
            }
        }

        private void DieInvaider()
        {
            InvaderLive = false;
            invaider.Fill = Brushes.Gray;
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

        private void StarshipGoGo()
        {
            MoveOnPress(starship, speed);
            BulletGoGo();
        }

        private void BulletGoGo()
        {
            if (Bullets != null && Bullets.Count != 0)
            {
                for (int i = 0; i < Bullets.Count; i++)
                {
                    Canvas.SetTop(Bullets[i], Canvas.GetTop(Bullets[i]) - 10);
                    if (Colision(Bullets[i], invaider)) { DieInvaider(); myCanvas.Children.Remove(Bullets[i]); Bullets.RemoveAt(i); break; }
                    if (Canvas.GetTop(Bullets[i]) < 20) { myCanvas.Children.Remove(Bullets[i]); Bullets.RemoveAt(i); }
                }
            }
        }

        private void InvaidersAtacks()
        {
            if (invaiderDir)
            {
                if (Canvas.GetLeft(invaider) + invaider.Width + 50 < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(invaider, Canvas.GetLeft(invaider) + speed);
                }

                else
                {
                    invaiderDir = false;
                    Canvas.SetTop(invaider, Canvas.GetTop(invaider) + invaider.Height);
                }
            }

            else
            {
                if (Canvas.GetLeft(invaider) > 50 )
                {
                    Canvas.SetLeft(invaider, Canvas.GetLeft(invaider) - speed);
                }

                else
                {
                    invaiderDir = true;
                    Canvas.SetTop(invaider, Canvas.GetTop(invaider) + invaider.Height);
                }
            }
        }

        private bool Colision(Shape Body1, Shape Body2)
        {
            return (Canvas.GetLeft(Body1) > Canvas.GetLeft(Body2))
                && (Canvas.GetLeft(Body1) < Canvas.GetLeft(Body2) + Body2.Width)
                && (Canvas.GetTop(Body1) > Canvas.GetTop(Body2))
                && (Canvas.GetTop(Body1) < Canvas.GetTop(Body2) + Body2.Height);
        }
    }
}