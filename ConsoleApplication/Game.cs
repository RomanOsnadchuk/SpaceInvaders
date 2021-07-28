using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Game
    {
        public Field Field { get; set; }
        public Sprite Starship { get; set; }
        public Sprite Alien { get; set; }
        public Sprite Bullet { get; set; }

        public void MoveStarship(int deltaX, int deltaY)
        {
                Starship.Position.Y += deltaY;
            if (Starship.Position.Y < 0) Starship.Position.Y = Field.Height-1;
            else if (Starship.Position.Y > Field.Height-1) Starship.Position.Y = 0;
               
                Starship.Position.X += deltaX;
            if (Starship.Position.X < 0) Starship.Position.X = Field.Width-1;
            else if (Starship.Position.X > Field.Width-1) Starship.Position.X = 0;
        }

        public void MoveAlien(int deltaX, int deltaY)
        {
            
            Alien.Position.X += deltaX;
            if (Alien.Position.X > Field.Width-1) { Alien.Position.X = 0; Alien.Position.Y += 1; }
            Alien.Position.Y += deltaY;
            if (Alien.Position.Y > Field.Height-1) Console.WriteLine("!!!GAME OVER!!!");
        }

        public void Shot()
        {
            var bullet = new Sprite();
            Bullet = bullet;
            bullet.Body = '|';
            bullet.Position.X = Starship.Position.X;
            bullet.Position.Y = Starship.Position.Y - 1;
        }

        internal void MoveShot(int deltaX, int deltaY)
        {
            if (Bullet != null)
            {
                Bullet.Position.X += deltaX;
                Bullet.Position.Y += deltaY;
                if (Bullet.Position.Y < 0) Bullet = null;
            } 
        }
    }
}
