using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CollisionDetector<T> : ICollisionDetector where T : IObject
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
        
        public CollisionDetector(IObject obj)
        {
            Object = obj;
        }

        private Collision DetectCollision(T foreignObject, int offset)
        {
            var thisPosition = Object.PositionRectangle;
            thisPosition.X -= offset;
            thisPosition.Y -= offset;
            thisPosition.Width += 2*offset;
            thisPosition.Height += 2*offset;
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

        public CollisionSideOld Detect(bool onlySolid = false, bool onlyActive = false, int offset = 1)
        {
            var side = new CollisionSideOld();
            foreach (var obj in Object.World.ObjectList)
            {
                if (obj is T && obj != Object && (obj.Solid || !onlySolid) && (obj.Solid || !onlyActive))
                {
                    switch (DetectCollision((T) obj, offset))
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