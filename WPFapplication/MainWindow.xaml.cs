﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

        int speed = 10;
        bool readyShot;
        private bool StartGame;
        private bool invaiderDir = true;
        bool InvaderLive = true;
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            game = new Game(10, 20, 1, ' ');
            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(1000/50);
            timer.Start();
        }


        private void MainTimerEvent(object sender, EventArgs e)
        {
            

            if (StartGame)
            {
                GameBox.Clear();

                if(Start.Visibility != Visibility.Hidden) Start.Visibility = Visibility.Hidden;
               // game.UpdateField();
                DrawField(game.Field, GameBox);
                game.MoveAlien(1, 0);
                game.MoveShot(0, -1);
                game.Collision();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: game.MoveStarship(-1,0); break;
                case Key.Right: game.MoveStarship(1, 0); break;
                case Key.Space: if (readyShot) game.Shot(); readyShot = false; break;
                case Key.Enter: StartGame = true; break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: break;
                case Key.Right: break;
                case Key.Space: readyShot = true; break;
            }
        }

        private void DrawField(Field field, TextBox textBox)
        {
            for (var i = 0; i < field.Height; i++)
            {
                textBox.Text += '|';
                for (var j = 0; j < field.Width; j++)
                    textBox.Text += field.FieldArray[i, j];
                textBox.Text += '|';
                textBox.Text += '\n';
            }
        }
    }
}