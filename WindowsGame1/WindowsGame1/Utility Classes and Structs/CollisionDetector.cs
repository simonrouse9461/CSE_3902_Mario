using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CollisionDetector<T> : ICollisionDetector where T : IObject
    {
        public enum Collision
        {
            None,
            Top,
            Bottom,
            Left,
            Right
        }

        protected IObject Object;
        
        public CollisionDetector(IObject obj)
        {
            Object = obj;
        }

        protected Collision DetectCollision(T foreignObject)
        {
            var thisPosition = Object.GetPositionRectangle();
            var foreignPosition = foreignObject.GetPositionRectangle();
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

        public CollisionSide Detect()
        {
            var side = new CollisionSide();
            foreach (var obj in Object.World.ObjectList)
            {
                if (obj is T && obj != Object)
                {
                    switch (DetectCollision((T) obj))
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