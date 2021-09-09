using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class Starship<T>
    {
        public Starship(T body, int x, int y, int directionAxis = 1)
        {
            Sprite<T> shipSprite = new Sprite<T>(body, x, y, directionAxis);
        }
        
    }
}
