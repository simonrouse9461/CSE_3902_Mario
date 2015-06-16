using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame1
{
   
    public class CollisionDetectorNew
    {
        private IObject CurrObject;
        private List<IObject> ObjectList;

        public CollisionDetectorNew(IObject obj, List<IObject> objList)
        {
            CurrObject = obj;
            ObjectList = objList;
        }

        private static CollisionSideNew DetectCollision(IObject currObject, IObject foreignObject)
        {
            var intersection = Rectangle.Intersect(currObject.GetPositionRectangle(), foreignObject.GetPositionRectangle());
            if (intersection != default(Rectangle))
            {
                if (intersection.Height > intersection.Width)
                {
                    if (foreignObject.GetPositionRectangle().Left > currObject.GetPositionRectangle().Left)
                        return CollisionSideNew.Right;
                    return CollisionSideNew.Left;
                }
                if (foreignObject.GetPositionRectangle().Top > currObject.GetPositionRectangle().Top)
                    return CollisionSideNew.Bottom;
                return CollisionSideNew.Top;
            }
            return CollisionSideNew.None;
        }

        public List<KeyValuePair<IObject, CollisionSideNew>> Detect()
        {
            var listOfCollisions = new List<KeyValuePair<IObject, CollisionSideNew>>();

            foreach (var foreignObj in ObjectList)
            {
                CollisionSideNew side = DetectCollision(CurrObject, foreignObj);
                if (!side.Equals(CollisionSideNew.None)) {
                    listOfCollisions.Add(new KeyValuePair<IObject,CollisionSideNew>(foreignObj, side));
                }
            }
            return listOfCollisions;
        }
    }
}