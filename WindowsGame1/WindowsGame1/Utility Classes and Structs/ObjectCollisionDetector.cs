using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class ObjectCollisionDetector<T> : ICollisionDetector where T : IObject
    {
        public enum Collision
        {
            None,
            Top,
            Bottom,
            Left,
            Right
        }

        protected static WorldManager World;

        protected IObject Object;
        
        public ObjectCollisionDetector(IObject obj)
        {
            Object = obj;
        }

        public static void Initialize(WorldManager world)
        {
            World = world;
        }

        protected Collision DetectCollision(T foreignObject)
        {
            var intersection = Rectangle.Intersect(Object.GetPositionRectangle(), foreignObject.GetPositionRectangle());
            if (intersection != default(Rectangle))
            {
                if (intersection.Height > intersection.Width)
                {
                    if (foreignObject.GetPositionRectangle().Left > Object.GetPositionRectangle().Left)
                        return Collision.Right;
                    return Collision.Left;
                }
                if (foreignObject.GetPositionRectangle().Top > Object.GetPositionRectangle().Top)
                    return Collision.Bottom;
                return Collision.Top;
            }
            return Collision.None;
        }

        public CollisionSide Detect()
        {
            var side = new CollisionSide();
            foreach (var obj in World.ObjectList)
            {
                if (obj is T)
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