using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BarrierDetector : IBarrierDetector
    {
        protected Collection<Type> BarrierList { get; private set; }
        protected Collection<Type> BarrierExceptionList { get; private set; }

        protected ICore Core { get; set; } 

        public BarrierDetector(ICore core)
        {
            Core = core;
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
        }

        private static bool RemoveType(Collection<Type> typeList, Type type)
        {
            var found = false;
            for (var i = 0; i < typeList.Count; i++)
            {
                var currentType = typeList[i];
                if (type.IsAssignableFrom(currentType))
                {
                    if (currentType.Equals(type))
                        found = true;
                    typeList.Remove(currentType);
                }
            }
            return found;
        }
        
        private static void AddType(Collection<Type> typeList, Type type)
        {
            foreach (var currentType in typeList)
            {
                if (currentType.IsAssignableFrom(type))
                    return;
            }
            typeList.Add(type);
        }

        public void AddBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof(T);
            if (!RemoveType(BarrierExceptionList, type))
                AddType(BarrierList, type);
        }

        public void RemoveBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof(T);
            if (!RemoveType(BarrierList, type))
               AddType(BarrierExceptionList, type);
        }

        public void ClearBarrier()
        {
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
        }

        public virtual void Detect()
        {
            var detector = Core.CollisionDetector;
            if (detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch &&
                !(Core.GeneralMotionState is StaticMotionState))
            {
                for (var collision = detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0);
                    collision.AnyEdge.Touch;
                    collision = detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0))
                {
                    if (collision.Bottom.Touch)
                        Core.GeneralMotionState.Adjust(new Vector2(0, -2));
                    if (detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Top.Touch)
                        Core.GeneralMotionState.Adjust(new Vector2(0, 2));
                    if (detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Left.Touch)
                        Core.GeneralMotionState.Adjust(new Vector2(2, 0));
                    if (detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Right.Touch)
                        Core.GeneralMotionState.Adjust(new Vector2(-2, 0));
                }
            }
        }
    }
}