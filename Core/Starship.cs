using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Starship<T>
    {
        public Sprite<T> shipSprite { get; set; }
        public List<Sprite<T>> Bullet = new List<Sprite<T>>();
        public Starship(T body, int x, int y, int directionAxis = 1)
        {
            shipSprite = new Sprite<T>(body, x, y, directionAxis);
        }


        
        public void Move(int deltaX, int deltaY)
        {
            shipSprite.Position.X = deltaX;
            shipSprite.Position.Y = deltaY;
        }

    }
}
