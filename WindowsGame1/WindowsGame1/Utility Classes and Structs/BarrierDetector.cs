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
        protected CollisionDetector Detector { get; private set; }

        public BarrierDetector(ICore core)
        {
            Core = core;
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
            Detector = new CollisionDetector(core.Object);
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
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch && Core.GeneralMotionState != null)
            {
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Bottom.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Top.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Left.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Right.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
            }
        }
    }
}