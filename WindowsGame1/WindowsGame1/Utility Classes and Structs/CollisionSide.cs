namespace WindowsGame1
{
    public struct CollisionSide
    {
        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;

        public bool Side()
        {
            return Left || Right;
        }
    }
}