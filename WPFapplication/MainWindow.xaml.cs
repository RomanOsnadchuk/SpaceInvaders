﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Core;

namespace WPFapplication
{
    public partial class MainWindow : Window
    {
        private readonly Game game;
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private bool InvaderLive = true;
        private bool invaiderDir = true;
        private bool readyShot;

        private int speed = 10;
        private bool StartGame;

        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            game = new Game(20, 20, 1, ' ');
            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(1000 / 50);
            timer.Start();
        }


        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (StartGame)
            {
                //GameBox.Clear();

                if (Start.Visibility != Visibility.Hidden) Start.Visibility = Visibility.Hidden;
                // game.UpdateField();
                //DrawField(game.Field, GameBox);
                Canvas.SetLeft(SS, 25 + (gameWindow.ActualWidth - 25*2) / game.Field.Width * game.Starship.Position.X);
                game.MoveAliens(1, 0);
                game.MoveShot(0, -1);
                game.Collision();
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