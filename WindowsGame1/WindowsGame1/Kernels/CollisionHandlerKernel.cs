using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TSpriteState, TMotionState> : ICollisionHandler
        where TSpriteState : SpriteStateKernel
        where TMotionState : MotionStateKernel
    {
        public State<TSpriteState, TMotionState> State { get; set; }
        public CollisionDetector Detector { get; set; }

        private readonly Collection<Type> BarrierList;
        private readonly Collection<Type> BarrierExceptionList;

        protected CollisionHandlerKernel(State<TSpriteState,TMotionState> state)
        {
            State = state;
            Detector = new CollisionDetector(State.Object);
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
        }

        public abstract void Handle();

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

        public void AddBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof(T);
            if (!RemoveType(BarrierExceptionList, type))
                BarrierList.Add(type);
        }

        public void RemoveBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof (T);
            if (!RemoveType(BarrierList, type))
                BarrierExceptionList.Add(type);
        }

        public void DetectBarrier()
        {
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Contact)
            {
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Bottom.Contact)
                    State.MotionState.Adjust(new Vector2(0, -1));
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Top.Contact)
                    State.MotionState.Adjust(new Vector2(0, 1));
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Left.Contact)
                    State.MotionState.Adjust(new Vector2(1, 0));
                while (Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0).Right.Contact)
                    State.MotionState.Adjust(new Vector2(-1, 0));
            }
        }
    }
}