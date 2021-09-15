using System;
using System.Collections.Generic;

namespace Core
{
    public class Game

    {
        public Field Field { get; set; }
        public GameObject Starship { get; set; }
        public List<GameObject> Alien { get; set; }
        public List<GameObject> Bullet { get; set; } = new List<GameObject>();

        public Game(int wigth , int height, int numberOfAlien, char backGround)
        {
            Field = new Field(wigth,height,backGround);
            Starship = new GameObject('Д', wigth/2, height);
            Alien = new List<GameObject>();
            for (int i = 0; i < numberOfAlien; i++)
            {
                Alien.Add(new GameObject('W',(i*1), 0));
            }
        }
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
            foreach (var alien in Alien)
            {

                alien.Position.X += deltaX;
                if (alien.Position.X > Field.Width - 1)
                {
                    alien.Position.X = 0;
                    alien.Position.Y += 1;
                }

                alien.Position.Y += deltaY;
                if (alien.Position.Y > Field.Height - 1) Console.WriteLine("!!!GAME OVER!!!");
            }
        }

        public void Shot()
        {
           Bullet.Add(new GameObject ('|', Starship.Position.X, Starship.Position.Y));
        }

        public void MoveShot(int deltaX, int deltaY)
        {
            for (var i = 0; i < Bullet.Count; i++)
            {
                Bullet[i].Position.X += deltaX;
                Bullet[i].Position.Y += deltaY;
                if (Bullet[i].Position.Y < 0) Bullet.RemoveAt(i);
            }
        }

        public void Collision()
        {
            for (var i = 0; i < Alien.Count; i++)
            {
                for (var j = 0; j < Bullet.Count; j++)
                    if (Alien[i].Position == Bullet[j].Position)
                    {
                        Bullet.RemoveAt(j);
                        Alien.RemoveAt(i);
                        break;
                    }
            }
        }
    }
}