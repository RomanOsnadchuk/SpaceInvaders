using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Starship:GameObject
    {
        
        //public List<GameObject<T>> Bullet = new List<GameObject<T>>();
        public Starship(object body, int x, int y, int directionAxis = 1):base(body, x, y, directionAxis)
        {
        }
        
        public void Move(int deltaX, int deltaY)
        {
            Position.X += deltaX;
            Position.Y += deltaY;
        }
    }
}
