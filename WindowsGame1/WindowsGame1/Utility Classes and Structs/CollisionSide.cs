namespace WindowsGame1
{
    public class CollisionSide
    {
        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;
        
        public CollisionSide()
        {
            Top = false;
            Bottom = false;
            Left = false;
            Right = false;
        }

        public bool Side()
        {
            return Left || Right;
        }
    }
}