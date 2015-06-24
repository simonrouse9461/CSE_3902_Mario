using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernelNew<TSpriteState, TMotionState> : ICollisionHandlerNew
        where TSpriteState : SpriteStateKernelNew
        where TMotionState : MotionStateKernelNew
    {
        public State<TSpriteState, TMotionState> State { get; set; }
        public CollisionDetectorNew Detector { get; set; }

        private readonly Collection<Type> BarrierList;

        protected CollisionHandlerKernelNew(State<TSpriteState,TMotionState> state)
        {
            State = state;
            Detector = new CollisionDetectorNew(State.Object);
            BarrierList = new Collection<Type>();
        }

        public abstract void Handle();

        public void AddBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof(T);
            BarrierList.Add(type);
        }

        public void RemoveBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof (T);
            for (var i = 0; i < BarrierList.Count; i++)
            {
                if (BarrierList[i].IsAssignableFrom(type))
                {
                    BarrierList.Remove(BarrierList[i]);
                }
            }
        }

        public void DetectBarrier()
        {
            foreach (var barrier in BarrierList)
            {
                if (Detector.Detect(barrier).AnyEdge.Contact)
                {
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Bottom.Contact)
                        State.MotionState.Adjust(new Vector2(0, -1));
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Top.Contact)
                        State.MotionState.Adjust(new Vector2(0, 1));
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Left.Contact)
                        State.MotionState.Adjust(new Vector2(1, 0));
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Right.Contact)
                        State.MotionState.Adjust(new Vector2(-1, 0));
                }
            }
        }
    }
}