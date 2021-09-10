using System;
using System.Collections.Generic;

namespace Core
{
    public class Game

    {
        public Field Field { get; set; }
        public GameObject Starship { get; set; }
        public GameObject Alien { get; set; }
        public List<GameObject> Bullet { get; set; } = new();

        public void MoveStarship(int deltaX, int deltaY)
        {
            Starship.Position.Y += deltaY;
            if (Starship.Position.Y < 0) Starship.Position.Y = Field.Height - 1;
            else if (Starship.Position.Y > Field.Height - 1) Starship.Position.Y = 0;

            Starship.Position.X += deltaX;
            if (Starship.Position.X < 0) Starship.Position.X = Field.Width - 1;
            else if (Starship.Position.X > Field.Width - 1) Starship.Position.X = 0;
        }

        public void MoveAlien(int deltaX, int deltaY)
        {
            Alien.Position.X += deltaX;
            if (Alien.Position.X > Field.Width - 1)
            {
                Alien.Position.X = 0;
                Alien.Position.Y += 1;
            }

            Alien.Position.Y += deltaY;
            if (Alien.Position.Y > Field.Height - 1) Console.WriteLine("!!!GAME OVER!!!");
        }

        public void Shot()
        {
           // Bullet.Add(new GameObject {Body = (object) '|', Starship.Position.X, Starship.Position.Y, });
        }

        public void MoveShot(int deltaX, int deltaY)
        {
            for (var i = 0; i < Bullet.Count; i++)
            {
                Bullet[i].Position.X = Bullet[i].Position.X + deltaX;
                Bullet[i].Position.Y = Bullet[i].Position.Y + deltaY;
                if (Bullet[i].Position.Y < 0) Bullet.RemoveAt(i);
            }
        }

        public void Colision()
        {
            for (var i = 0; i < Bullet.Count; i++)
                if (Alien.Position == Bullet[i].Position)
                {
                    Bullet.RemoveAt(i);
                    Alien = null;
                    break;
                }
        }
    }
}