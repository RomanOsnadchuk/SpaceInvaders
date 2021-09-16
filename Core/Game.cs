using System.Collections.Generic;

namespace Core
{
    public class Game

    {
        private int distanceAlien = 5;
        public Field Field {get;}
        private GameObject Starship {get;}
        private List<GameObject> Alien { get;}
        private List<GameObject> Bullet { get;} = new List<GameObject>();

        public Game(int width , int height, int numberOfAlien, char backGround)
        {
            Field = new Field(width,height,backGround);

            Starship = new GameObject('Д', width/2, height-1);

            Alien = new List<GameObject>();

            for (int i = 0, j = 0; i < numberOfAlien; i++)
            {
                if (i * distanceAlien - j * width < width)
                    Alien.Add(new GameObject('W', (i * distanceAlien - j * width), j));
                else
                {
                    j++;
                    Alien.Add(new GameObject('W', (i * distanceAlien - j * width), j));
                }
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
            }
        }

        public void Shot()
        {
           Bullet.Add(new GameObject ('*', Starship.Position.X, Starship.Position.Y-1));
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
                {
                    if (Alien[i].Position == Bullet[j].Position)
                    {
                        Bullet.RemoveAt(j);
                        Alien.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void UpdateField()
        {
            Field.ZeroField();
            Field.Set(Starship);
            foreach (var alien in Alien) Field.Set(alien);
            foreach (var bullet in Bullet) if (Bullet != null) Field.Set(bullet);
        }

        public bool AlienIsDie()
        {
            return Alien.Count == 0;
        }

        public bool AlienIsWin()
        {
            foreach (var alien in Alien)
            {
                if (alien.Position.Y == Field.Height - 1) return true;
            }

            return false;
        }
    }
}