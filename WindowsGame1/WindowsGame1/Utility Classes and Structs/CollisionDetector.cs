using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CollisionDetector : ICollisionDetector
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

        private readonly IObject _object;

        public CollisionDetector(IObject obj)
        {
            _object = obj;
        }

        private static RelativePosition ComparePosition(Rectangle subjectRectangle, Rectangle objectRectangle)
        {
            var intersectionRectangle = Rectangle.Intersect(subjectRectangle, objectRectangle);
            var Subject = new RectangleParser(subjectRectangle);
            var Object = new RectangleParser(objectRectangle);
            var Intersection = new RectangleParser(intersectionRectangle);

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
            var Subject = new RectangleParser(subjectRectangle);
            var Object = new RectangleParser(objectRectangle);
            var Intersection = new RectangleParser(intersectionRectangle);
            var covered = default(CollisionType).SetToCover();
            var touched = default(CollisionType).SetToContact();
            var returnValue = new Collision();

            if (subjectRectangle.Intersects(objectRectangle))
            {
                switch (ComparePosition(subjectRectangle, objectRectangle))
                {
                    case RelativePosition.Inside:
                        return new Collision {AllEdge = touched};
                    case RelativePosition.Around:
                        return new Collision {AllEdge = covered};
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
                            switch (Math.Sign(Intersection.Right.CompareTo(Subject.VerticalMidline)))
                            {
                                case 1:
                                    returnValue.TopRight = touched;
                                    returnValue.TopLeft = covered;
                                    break;
                                case 0:
                                    returnValue.TopLeft = covered;
                                    break;
                                case -1:
                                    returnValue.TopLeft = touched;
                                    break;
                            }
                        }
                        else
                        {
                            switch (Math.Sign(Intersection.Bottom.CompareTo(Subject.HotizontalMidline)))
                            {
                                case 1:
                                    returnValue.LeftBottom = touched;
                                    returnValue.LeftTop = covered;
                                    break;
                                case 0:
                                    returnValue.LeftTop = covered;
                                    break;
                                case -1:
                                    returnValue.LeftTop = touched;
                                    break;
                            }
                        }
                        return returnValue;
                    case RelativePosition.UpperRight:
                        if (Intersection.Width >= Intersection.Height)
                        {
                            switch (Math.Sign(Intersection.Left.CompareTo(Subject.VerticalMidline)))
                            {
                                case -1:
                                    returnValue.TopLeft = touched;
                                    returnValue.TopRight = covered;
                                    break;
                                case 0:
                                    returnValue.TopRight = covered;
                                    break;
                                case 1:
                                    returnValue.TopRight = touched;
                                    break;
                            }
                        }
                        else
                        {
                            switch (Math.Sign(Intersection.Bottom.CompareTo(Subject.HotizontalMidline)))
                            {
                                case 1:
                                    returnValue.RightBottom = touched;
                                    returnValue.RightTop = covered;
                                    break;
                                case 0:
                                    returnValue.RightTop = covered;
                                    break;
                                case -1:
                                    returnValue.RightTop = touched;
                                    break;
                            }
                        }
                        return returnValue;
                    case RelativePosition.LowerLeft:
                        if (Intersection.Width >= Intersection.Height)
                        {
                            switch (Math.Sign(Intersection.Right.CompareTo(Subject.VerticalMidline)))
                            {
                                case 1:
                                    returnValue.BottomRight = touched;
                                    returnValue.BottomLeft = covered;
                                    break;
                                case 0:
                                    returnValue.BottomLeft = covered;
                                    break;
                                case -1:
                                    returnValue.BottomLeft = touched;
                                    break;
                            }
                        }
                        else
                        {
                            switch (Math.Sign(Intersection.Top.CompareTo(Subject.HotizontalMidline)))
                            {
                                case -1:
                                    returnValue.LeftTop = touched;
                                    returnValue.LeftBottom = covered;
                                    break;
                                case 0:
                                    returnValue.LeftBottom = covered;
                                    break;
                                case 1:
                                    returnValue.LeftBottom = touched;
                                    break;
                            }
                        }
                        return returnValue;
                    case RelativePosition.LowerRight:
                        if (Intersection.Width >= Intersection.Height)
                        {
                            switch (Math.Sign(Intersection.Left.CompareTo(Subject.VerticalMidline)))
                            {
                                case -1:
                                    returnValue.BottomLeft = touched;
                                    returnValue.BottomRight = covered;
                                    break;
                                case 0:
                                    returnValue.BottomRight = covered;
                                    break;
                                case 1:
                                    returnValue.BottomRight = touched;
                                    break;
                            }
                        }
                        else
                        {
                            switch (Math.Sign(Intersection.Top.CompareTo(Subject.HotizontalMidline)))
                            {
                                case -1:
                                    returnValue.RightTop = touched;
                                    returnValue.RightBottom = covered;
                                    break;
                                case 0:
                                    returnValue.RightBottom = covered;
                                    break;
                                case 1:
                                    returnValue.RightBottom = touched;
                                    break;
                            }
                        }
                        return returnValue;
                }
            }
            return returnValue;
        }

        private static Collision SearchCollision<T>(IObject Object, Func<IObject, bool> typeFilter, Func<T, bool> PropertyFilter, int offset) where T : IObject
        {
            var collision = new Collision();
            var objectRectangle = SetOffset(Object.PositionRectangle, offset);
            foreach (var obj in WorldManager.Instance.ObjectList)
            {
                if (!ReferenceEquals(obj, Object) && typeFilter(obj) && PropertyFilter((T)obj))
                {
                    collision += DetectCollision(objectRectangle, obj.PositionRectangle);
                }
            }
            return collision;
        }

        private static Rectangle SetOffset(Rectangle rectangle, int offset)
        {
            rectangle.X -= offset;
            rectangle.Y -= offset;
            rectangle.Width += 2 * offset;
            rectangle.Height += 2 * offset;
            return rectangle;
        }

        public Collision Detect(Collection<Type> types, Collection<Type> exceptionTypes = null, Func<IObject, bool> filter = null, int offset = 1)
        {
            var propertyFilter = filter ?? (obj => true);
            Func<IObject, bool> typeFilter = obj =>
            {
                var pass = false;
                foreach (var type in types)
                {
                    if (type.IsInstanceOfType(obj))
                    {
                        pass = true;
                        break;
                    }
                }
                if (!pass) return false;
                foreach (var type in exceptionTypes)
                {
                    if (type.IsInstanceOfType(obj))
                    {
                        return false;
                    }
                }
                return true;
            };
            
            return SearchCollision(_object, typeFilter, propertyFilter, offset);
        }

        public Collision Detect<T>(Func<T, bool> filter = null, int offset = 1) where T : IObject
        {
            var propertyFilter = filter ?? (obj => true);
            Func<IObject, bool> typeFilter = obj => obj is T;

            return SearchCollision(_object, typeFilter, propertyFilter, offset);
        }
    }
}