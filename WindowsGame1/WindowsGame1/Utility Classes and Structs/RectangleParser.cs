using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public struct RectangleParser
    {
        private Rectangle _rectangle;

        public Vector2 Origin
        {
            get { return new Vector2(_rectangle.X, _rectangle.Y); }
        }

        public int Width
        {
            get { return _rectangle.Width; }
        }

        public int Height
        {
            get { return _rectangle.Height; }
        }

        public int Top
        {
            get { return _rectangle.Y; }
        }

        public int Bottom
        {
            get { return _rectangle.Y + Height; }
        }

        public int Left
        {
            get { return _rectangle.X; }
        }

        public int Right
        {
            get { return _rectangle.X + Width; }
        }

        public int HotizontalMidline
        {
            get { return _rectangle.Y + Height / 2; }
        }

        public int VerticalMidline
        {
            get { return _rectangle.X + Width / 2; }
        }

        public Vector2 UpperLeft
        {
            get { return Origin; }
        }

        public Vector2 UpperRight
        {
            get { return new Vector2(Right, Top); }
        }

        public Vector2 LowerLeft
        {
            get { return new Vector2(Left, Bottom); }
        }

        public Vector2 LowerRight
        {
            get { return new Vector2(Right, Bottom); }
        }

        public Vector2 MidLeft
        {
            get { return new Vector2(Left, HotizontalMidline); }
        }

        public Vector2 MidRight
        {
            get { return new Vector2(Left, HotizontalMidline); }
        }

        public Vector2 MidTop
        {
            get { return new Vector2(VerticalMidline, Top); }
        }

        public Vector2 MidBottom
        {
            get { return new Vector2(VerticalMidline, Bottom); }
        }

        public Vector2 Center
        {
            get { return new Vector2(VerticalMidline, HotizontalMidline); }
        }

        public RectangleParser(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public bool HavePoint(Vector2 point)
        {
            return _rectangle.Contains((int)point.X, (int)point.Y);
        }

        public static bool operator ==(RectangleParser a, RectangleParser b)
        {
            return a._rectangle == b._rectangle;
        }

        public static bool operator !=(RectangleParser a, RectangleParser b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is RectangleParser)
                return this == (RectangleParser)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}