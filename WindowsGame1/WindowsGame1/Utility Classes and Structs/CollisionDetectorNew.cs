using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CollisionDetectorNew : ICollisionDetectorNew
    {
        private enum RelativePosition
        {
            Outside,
            Inside,
            Around,
            VerticalThrough,
            HorizontalThrough,
            InlayAbove,
            InlayBeneath,
            InlayLeft,
            InlayRight,
            CoverAbove,
            CoverBeneath,
            CoverLeft,
            CoverRight,
            UpperLeft,
            UpperRight,
            LowerLeft,
            LowerRight
        }

        private struct RectangleSpec
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
                get { return _rectangle.Y + Height/2; }
            }

            public int VerticalMidline
            {
                get { return _rectangle.X + Width/2; }
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

            public RectangleSpec(Rectangle rectangle)
            {
                _rectangle = rectangle;
            }

            public bool HavePoint(Vector2 point)
            {
                return _rectangle.Contains((int) point.X, (int) point.Y);
            }

            public static bool operator ==(RectangleSpec a, RectangleSpec b)
            {
                return a._rectangle == b._rectangle;
            }

            public static bool operator !=(RectangleSpec a, RectangleSpec b)
            {
                return !(a == b);
            }
        }

        private readonly IObject _object;

        public CollisionDetectorNew(IObject obj)
        {
            _object = obj;
        }

        private static RelativePosition ComparePosition(Rectangle subjectRectangle, Rectangle objectRectangle)
        {
            var intersectionRectangle = Rectangle.Intersect(subjectRectangle, objectRectangle);
            var Subject = new RectangleSpec(subjectRectangle);
            var Object = new RectangleSpec(objectRectangle);
            var Intersection = new RectangleSpec(intersectionRectangle);

            if (Object == Intersection)
                return RelativePosition.Inside;
            if (Subject == Intersection)
                return RelativePosition.Around;
            if (Subject.Width == Intersection.Width)
            {
                if (Object.Height == Intersection.Height)
                    return RelativePosition.HorizontalThrough;
                if (Object.Bottom == Intersection.Bottom)
                    return RelativePosition.CoverAbove;
                if (Object.Top == Intersection.Top)
                    return RelativePosition.CoverBeneath;
            }
            if (Subject.Height == Intersection.Height)
            {
                if (Object.Width == Intersection.Width)
                    return RelativePosition.VerticalThrough;
                if (Object.Right == Intersection.Right)
                    return RelativePosition.CoverLeft;
                if (Object.Left == Intersection.Left)
                    return RelativePosition.CoverRight;
            }
            if (Object.Width == Intersection.Width)
            {
                if (Object.Top == Intersection.Top)
                    return RelativePosition.InlayBeneath;
                if (Object.Bottom == Intersection.Bottom)
                    return RelativePosition.InlayAbove;
            }
            if (Object.Height == Intersection.Height)
            {
                if (Object.Left == Intersection.Left)
                    return RelativePosition.InlayRight;
                if (Object.Right == Intersection.Right)
                    return RelativePosition.InlayLeft;
            }
            if (Object.HavePoint(Subject.UpperLeft))
                return RelativePosition.UpperLeft;
            if (Object.HavePoint(Subject.UpperRight))
                return RelativePosition.UpperRight;
            if (Object.HavePoint(Subject.LowerLeft))
                return RelativePosition.LowerLeft;
            if (Object.HavePoint(Subject.LowerRight))
                return RelativePosition.LowerRight;
            return RelativePosition.Outside;
        }

        private static Collision DetectCollision(Rectangle subjectRectangle, Rectangle objectRectangle)
        {
            var intersectionRectangle = Rectangle.Intersect(subjectRectangle, objectRectangle);
            var Subject = new RectangleSpec(subjectRectangle);
            var Object = new RectangleSpec(objectRectangle);
            var Intersection = new RectangleSpec(intersectionRectangle);
            var covered = default(Collision.CollisionType).SetToCover();
            var touched = default(Collision.CollisionType).SetToContact();
            var returnValue = new Collision();

            if (subjectRectangle.Intersects(objectRectangle))
            {
                switch (ComparePosition(subjectRectangle, objectRectangle))
                {
                    case RelativePosition.Inside:
                    case RelativePosition.Around:
                        return new Collision
                        {
                            AllEdge = covered
                        };
                    case RelativePosition.VerticalThrough:
                        if (Object.Left <= Subject.VerticalMidline)
                            returnValue.Left = covered;
                        if (Object.Right >= Subject.VerticalMidline)
                            returnValue.Right = covered;
                        return returnValue;
                    case RelativePosition.HorizontalThrough:
                        if (Object.Top <= Subject.HotizontalMidline)
                            returnValue.Top = covered;
                        if (Object.Bottom >= Subject.HotizontalMidline)
                            returnValue.Bottom = covered;
                        return returnValue;
                    case RelativePosition.InlayAbove:
                        if (Object.Left < Subject.VerticalMidline && Object.Right > Subject.VerticalMidline)
                        {
                            returnValue.TopLeft = Object.Left == Subject.Left ? covered : touched;
                            returnValue.TopRight = Object.Right == Subject.Right ? covered : touched;
                        }
                        else 
                        {
                            if (Object.Left < Subject.VerticalMidline)
                            {
                                if (Object.Left == Subject.Left && Object.Right == Subject.VerticalMidline)
                                    returnValue.TopLeft = covered;
                                else
                                    returnValue.TopLeft = touched;
                            }
                            else
                            {
                                if (Object.Left == Subject.VerticalMidline && Object.Right == Subject.Right)
                                    returnValue.TopRight = covered;
                                else
                                    returnValue.TopRight = touched;
                            }
                        }
                        return returnValue;
                    case RelativePosition.InlayBeneath:
                        if (Object.Left < Subject.VerticalMidline && Object.Right > Subject.VerticalMidline)
                        {
                            returnValue.BottomLeft = Object.Left == Subject.Left ? covered : touched;
                            returnValue.BottomRight = Object.Right == Subject.Right ? covered : touched;
                        }
                        else 
                        {
                            if (Object.Left < Subject.VerticalMidline)
                            {
                                if (Object.Left == Subject.Left && Object.Right == Subject.VerticalMidline)
                                    returnValue.BottomLeft = covered;
                                else
                                    returnValue.BottomLeft = touched;
                            }
                            else
                            {
                                if (Object.Left == Subject.VerticalMidline && Object.Right == Subject.Right)
                                    returnValue.BottomRight = covered;
                                else
                                    returnValue.BottomRight = touched;
                            }
                        }
                        return returnValue;
                    case RelativePosition.InlayLeft:
                        if (Object.Top < Subject.HotizontalMidline && Object.Bottom > Subject.HotizontalMidline)
                        {
                            returnValue.LeftTop = Object.Top == Subject.Top ? covered : touched;
                            returnValue.LeftBottom = Object.Bottom == Subject.Bottom ? covered : touched;
                        }
                        else 
                        {
                            if (Object.Top < Subject.HotizontalMidline)
                            {
                                if (Object.Top == Subject.Top && Object.Bottom == Subject.HotizontalMidline)
                                    returnValue.LeftTop = covered;
                                else
                                    returnValue.LeftTop = touched;
                            }
                            else
                            {
                                if (Object.Top == Subject.HotizontalMidline && Object.Bottom == Subject.Bottom)
                                    returnValue.LeftBottom = covered;
                                else
                                    returnValue.LeftBottom = touched;
                            }
                        }
                        return returnValue;
                    case RelativePosition.InlayRight:
                        if (Object.Top < Subject.HotizontalMidline && Object.Bottom > Subject.HotizontalMidline)
                        {
                            returnValue.RightTop = Object.Top == Subject.Top ? covered : touched;
                            returnValue.RightBottom = Object.Bottom == Subject.Bottom ? covered : touched;
                        }
                        else 
                        {
                            if (Object.Top < Subject.HotizontalMidline)
                            {
                                if (Object.Top == Subject.Top && Object.Bottom == Subject.HotizontalMidline)
                                    returnValue.RightTop = covered;
                                else
                                    returnValue.RightTop = touched;
                            }
                            else
                            {
                                if (Object.Top == Subject.HotizontalMidline && Object.Bottom == Subject.Bottom)
                                    returnValue.RightBottom = covered;
                                else
                                    returnValue.RightBottom = touched;
                            }
                        }
                        return returnValue;
                    case RelativePosition.CoverAbove:
                        return new Collision {Top = covered};
                    case RelativePosition.CoverBeneath:
                        return new Collision {Bottom = covered};
                    case RelativePosition.CoverLeft:
                        return new Collision {Left = covered};
                    case RelativePosition.CoverRight:
                        return new Collision {Right = covered};
                    case RelativePosition.UpperLeft:
                        if (Intersection.Width >= Intersection.Height)
                        {
                            if (Intersection.Right > Subject.VerticalMidline)
                            {
                                returnValue.TopRight = touched;
                                returnValue.TopLeft = covered;
                            }
                            else if (Intersection.Right == Subject.VerticalMidline)
                                returnValue.TopLeft = covered;
                            else
                                returnValue.TopLeft = touched;
                        }
                        else
                        {
                            if (Intersection.Bottom > Subject.HotizontalMidline)
                            {
                                
                            }
                            return new Collision {LeftTop = covered};
                            return new Collision {LeftTop = touched};
                        }
                    case RelativePosition.UpperRight:
                        if (Intersection.Width >= Intersection.Height)
                        {
                            if (Intersection.Left == Subject.VerticalMidline)
                                return new Collision {TopRight = covered};
                            return new Collision {TopRight = touched};
                        }
                        if (Intersection.Bottom == Subject.HotizontalMidline)
                            return new Collision {RightTop = covered};
                        return new Collision {RightTop = touched};
                    case RelativePosition.LowerLeft:
                        if (Intersection.Width >= Intersection.Height)
                        {
                            if (Intersection.Right == Subject.VerticalMidline)
                                return new Collision {BottomLeft = covered};
                            return new Collision {BottomLeft = touched};
                        }
                        if (Intersection.Top == Subject.HotizontalMidline)
                            return new Collision {LeftTop = covered};
                        return new Collision {LeftTop = touched};
                    case RelativePosition.LowerRight:
                        break;
                }
            }

//            var thisPosition = _object.PositionRectangle;
//            thisPosition.X -= offset;
//            thisPosition.Y -= offset;
//            thisPosition.Width += 2 * offset;
//            thisPosition.Height += 2 * offset;
//            var foreignPosition = foreignObject.PositionRectangle;
//            var intersection = Rectangle.Intersect(thisPosition, foreignPosition);
//            if (thisPosition.Intersects(foreignPosition))
//            {
//                if (intersection.Height > intersection.Width)
//                {
//                    if (foreignPosition.Left > thisPosition.Left)
//                        return Collision.Right;
//                    return Collision.Left;
//                }
//                if (foreignPosition.Top > thisPosition.Top)
//                    return Collision.Bottom;
//                return Collision.Top;
//            }
//            return Collision.None;
        }

        public Collision Detect(Type type, Func<IObject, bool> condition = null, int offset = 1)
        {
            condition = condition ?? (obj => true);
            var side = new Collision();
            foreach (var obj in _object.World.ObjectList)
            {
                if (type.IsInstanceOfType(obj) && obj != _object && condition(obj))
                {
                    switch (DetectCollision(obj, offset))
                    {
                        case Collision.Top:
                            side.Top = true;
                            break;
                        case Collision.Bottom:
                            side.Bottom = true;
                            break;
                        case Collision.Left:
                            side.Left = true;
                            break;
                        case Collision.Right:
                            side.Right = true;
                            break;
                    }
                }
            }
            return side;
        }

        public Collision Detect<T>(Func<T, bool> condition = null, int offset = 1) where T : IObject
        {
            condition = condition ?? (obj => true);
            var side = new Collision();
            foreach (var obj in _object.World.ObjectList)
            {
                if (obj is T && obj != _object && condition((T)obj))
                {
                    switch (DetectCollision((T)obj, offset))
                    {
                        case Collision.Top:
                            side.Top = true;
                            break;
                        case Collision.Bottom:
                            side.Bottom = true;
                            break;
                        case Collision.Left:
                            side.Left = true;
                            break;
                        case Collision.Right:
                            side.Right = true;
                            break;
                    }
                }
            }
            return side;
        }
    }
}