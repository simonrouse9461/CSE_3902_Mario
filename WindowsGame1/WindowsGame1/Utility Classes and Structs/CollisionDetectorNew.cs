using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CollisionDetectorNew : ICollisionDetectorNew
    {
        private enum Collision
        {
            None,
            Top,
            Bottom,
            Left,
            Right
        }

        private IObject Object;

        public CollisionDetectorNew(IObject obj)
        {
            Object = obj;
        }

        private Collision DetectCollision(IObject foreignObject, int offset)
        {
            var thisPosition = Object.PositionRectangle;
            thisPosition.X -= offset;
            thisPosition.Y -= offset;
            thisPosition.Width += 2 * offset;
            thisPosition.Height += 2 * offset;
            var foreignPosition = foreignObject.PositionRectangle;
            var intersection = Rectangle.Intersect(thisPosition, foreignPosition);
            if (thisPosition.Intersects(foreignPosition))
            {
                if (intersection.Height > intersection.Width)
                {
                    if (foreignPosition.Left > thisPosition.Left)
                        return Collision.Right;
                    return Collision.Left;
                }
                if (foreignPosition.Top > thisPosition.Top)
                    return Collision.Bottom;
                return Collision.Top;
            }
            return Collision.None;
        }

        public CollisionSideNew Detect(Type type, Func<IObject, bool> condition = null, int offset = 1)
        {
            condition = condition ?? (obj => true);
            var side = new CollisionSideNew();
            foreach (var obj in Object.World.ObjectList)
            {
                if (type.IsInstanceOfType(obj) && obj != Object && condition(obj))
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

        public CollisionSideNew Detect<T>(Func<T, bool> condition = null, int offset = 1) where T : IObject
        {
            condition = condition ?? (obj => true);
            var side = new CollisionSideNew();
            foreach (var obj in Object.World.ObjectList)
            {
                if (obj is T && obj != Object && condition((T)obj))
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