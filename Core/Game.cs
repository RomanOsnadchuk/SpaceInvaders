using System.Collections.Generic;

namespace Core
{
    public class Game
    {
        public Game(int width, int height, int numberOfAliens, char backGround)
        {
            Field = new Field(width, height, backGround);
            DistanceAlien = 5;
            Starship = new GameObject('Д', width / 2, height - 1);
            Bullets = new List<GameObject>();
            Field.Set(Starship);

            Aliens = new List<GameObject>();

            for (int i = 0, j = 0; i < numberOfAliens; i++)
                if (i * DistanceAlien - j * width < width)
                {
                    Aliens.Add(new GameObject('W', i * DistanceAlien - j * width, j));
                    Field.Set(Aliens[i]);
                }
                else
                {
                    j++;
                    Aliens.Add(new GameObject('W', i * DistanceAlien - j * width, j));
                    Field.Set(Aliens[i]);
                }
        }

        public Game(Field field, GameObject starship, List<GameObject> aliens, List<GameObject> bullets)
        {
            Field = field;
            Starship = starship;
            Aliens = aliens;
            Bullets = bullets;
        }

        private int DistanceAlien { get; }
        public Field Field { get; }
        public GameObject Starship { get; }
        public List<GameObject> Aliens { get; }
        public List<GameObject> Bullets { get; }

        public void MoveStarship(int deltaX, int deltaY)
        {
            Field.ZeroPosition(Starship);
            Starship.Position.Y += deltaY;
            if (Starship.Position.Y < 0) Starship.Position.Y = Field.Height - 1;
            else if (Starship.Position.Y > Field.Height - 1) Starship.Position.Y = 0;

            Starship.Position.X += deltaX;
            if (Starship.Position.X < 0) Starship.Position.X = Field.Width - 1;
            else if (Starship.Position.X > Field.Width - 1) Starship.Position.X = 0;
            Field.Set(Starship);
        }

        public void MoveAliens(int deltaX, int deltaY)
        {
            for (var i = 0; i < Aliens.Count; i++)
            {
                Field.ZeroPosition(Aliens[i]);
                Aliens[i].Position.X += deltaX;
                if (Aliens[i].Position.X > Field.Width - 1)
                {
                    Aliens[i].Position.X = 0;
                    Aliens[i].Position.Y += 1;
                }

                Aliens[i].Position.Y += deltaY;
                Field.Set(Aliens[i]);
            }
        }

        public void Shot()
        {
            Bullets.Add(new GameObject('*', Starship.Position.X, Starship.Position.Y - 1));
            Field.Set(Bullets[Bullets.Count - 1]);
        }

        public void MoveShot(int deltaX, int deltaY)
        {
            for (var i = 0; i < Bullets.Count; i++)
            {
                Field.ZeroPosition(Bullets[i]);
                Bullets[i].Position.X += deltaX;
                Bullets[i].Position.Y += deltaY;
                if (Bullets[i].Position.Y < 0)
                {
                    Bullets.RemoveAt(i);
                    continue;
                }

                Field.Set(Bullets[i]);
            }
        }

        public void Collision()
        {
            for (var i = 0; i < Aliens.Count; i++)
            for (var j = 0; j < Bullets.Count; j++)
                if (Aliens[i].Position == Bullets[j].Position)
                {
                    Field.ZeroPosition(Bullets[j]);
                    Bullets.RemoveAt(j);
                    Aliens.RemoveAt(i);
                    break;
                }
        }

        /*public void UpdateField()
        {
            Field.ZeroField();
            Field.Set(Starship);
            foreach (var alien in Aliens) Field.Set(alien);
            foreach (var bullet in Bullets)
                if (bullet != null)
                    Field.Set(bullet);
        }*/

        public bool AliensIsDie()
        {
            return Aliens.Count == 0;
        }

        public bool AliensIsWin()
        {
            foreach (var alien in Aliens)
                if (alien.Position.Y == Field.Height - 1)
                    return true;

            return false;
        }
    }
}