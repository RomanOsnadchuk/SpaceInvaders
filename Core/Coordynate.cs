using System;

namespace Core
{
    public class Coordynate : IEquatable<Coordynate>
    {
        public Coordynate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }


        public bool Equals(Coordynate other)

        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Coordynate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Coordynate left, Coordynate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coordynate left, Coordynate right)
        {
            return !Equals(left, right);
        }
    }
}