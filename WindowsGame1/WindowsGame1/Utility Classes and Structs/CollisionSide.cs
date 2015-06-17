namespace WindowsGame1
{
    public struct CollisionSide
    {
        public bool Top { get; set; }
        public bool Bottom { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public static bool operator ==(CollisionSide a, CollisionSide b)
        {
            return a.Top == b.Top && a.Bottom == b.Bottom && a.Left == b.Left && a.Right == b.Right;
        }

        public static bool operator !=(CollisionSide a, CollisionSide b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is CollisionSide && this == (CollisionSide)obj;
        }

        public bool Side()
        {
            return Left || Right;
        }

        public bool Any()
        {
            return Left || Right || Top || Bottom;
        }
    }
}