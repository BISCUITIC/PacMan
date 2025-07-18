﻿namespace Pac_Man.CoordinatesSystem
{
    internal class Vector2i
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Vector2i Zero = new Vector2i(0, 0);

        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Vector2i((int x, int y) tuple)
        {
            return new Vector2i(tuple.x, tuple.y);
        }
        public static implicit operator (int x, int y)(Vector2i vec2i)
        {
            return (vec2i.X, vec2i.Y);
        }

        public static Vector2i operator +(Vector2i first, Vector2i second)
        {
            return new Vector2i(first.X + second.X, first.Y + second.Y);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
