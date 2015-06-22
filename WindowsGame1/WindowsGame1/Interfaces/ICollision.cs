namespace WindowsGame1
{
    public interface ICollision
    {
         CollisionType TopLeft { get; set; }
         CollisionType TopRight { get; set; }
         CollisionType BottomLeft { get; set; }
         CollisionType BottomRight { get; set; }
         CollisionType LeftTop { get; set; }
         CollisionType LeftBottom { get; set; }
         CollisionType RightTop { get; set; }
         CollisionType RightBottom { get; set; }

         CollisionType Top { get; set; }
         CollisionType Bottom
        {
            get { return BottomLeft & BottomRight; }
            set
            {
                BottomLeft = value;
                BottomRight = value;
            }
        }

         CollisionType Left
        {
            get { return LeftTop & LeftBottom; }
            set
            {
                LeftTop = value;
                LeftBottom = value;
            }
        }

         CollisionType Right
        {
            get { return RightTop & RightBottom; }
            set
            {
                RightTop = value;
                RightBottom = value;
            }
        }

         CollisionType AnySide
        {
            get { return Left | Right; }
        }

         CollisionType BothSide
        {
            get { return Left & Right; }
            set
            {
                Left = value;
                Right = value;
            }
        }

         CollisionType AnyEdge
        {
            get { return AnySide | Top | Bottom; }
        }

         CollisionType AllEdge
        {
            get { return AnySide & Top & Bottom; }
            set
            {
                BothSide = value;
                Top = value;
                Bottom = value;
            }
        }

         static bool operator ==(Collision a, Collision b)
        {
            return a.TopLeft == b.TopLeft
                && a.TopRight == b.TopRight
                && a.BottomLeft == b.BottomLeft
                && a.BottomRight == b.BottomRight
                && a.LeftTop == b.LeftTop
                && a.LeftBottom == b.LeftBottom
                && a.RightTop == b.RightTop
                && a.RightBottom == b.RightBottom;
        }

         static bool operator !=(Collision a, Collision b)
        {
            return !(a == b);
        }

         static Collision operator +(Collision a, Collision b)
    }
}