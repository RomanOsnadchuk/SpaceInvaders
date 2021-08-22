using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Input;
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
        bool goLeft, goRight, Shot;

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
            Canvas.SetBottom(starship, Canvas.GetTop(starship) + 0);

            if (goLeft == true && Canvas.GetLeft(starship) > 0)
            {
                Canvas.SetLeft(starship, Canvas.GetLeft(starship) - speed);
            }
            if (goRight == true && Canvas.GetLeft(starship) + (starship.Width + 24) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(starship, Canvas.GetLeft(starship) + speed);
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
                Shot = true;
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

       
    }
}