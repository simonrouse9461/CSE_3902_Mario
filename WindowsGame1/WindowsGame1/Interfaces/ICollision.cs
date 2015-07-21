namespace MarioGame
{
    public interface ICollision
    {
        // detailed information
        CollisionType TopLeft { get; set; }
        CollisionType TopRight { get; set; }
        CollisionType BottomLeft { get; set; }
        CollisionType BottomRight { get; set; }
        CollisionType LeftTop { get; set; }
        CollisionType LeftBottom { get; set; }
        CollisionType RightTop { get; set; }
        CollisionType RightBottom { get; set; }

        // general
        CollisionType Top { get; set; }
        CollisionType Bottom { get; set; }
        CollisionType Left { get; set; }
        CollisionType Right { get; set; }

        // more general
        CollisionType AnySide { get; }
        CollisionType BothSide { get; set; }

        // most general
        CollisionType AnyEdge { get; }
        CollisionType AllEdge { get; set; }

        // operation
        Collision Add(Collision collision); // alternate of operator +
    }
}