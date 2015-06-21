using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernelNew<TSpriteState, TMotionState> : ICollisionHandler
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected IObject Object { get; set; }
        protected TSpriteState SpriteState { get; set; }
        protected TMotionState MotionState { get; set; }
        protected CollisionDetectorNew Detector { get; private set; }
        public bool Solid { get; set; }

        private readonly Collection<Type> BarrierList;

        protected CollisionHandlerKernelNew(TSpriteState spriteState, TMotionState motionState, IObject obj)
        {
            SpriteState = spriteState;
            MotionState = motionState;
            Object = obj;
            Solid = true;
            Detector = new CollisionDetectorNew(Object);
            BarrierList = new Collection<Type>();
            Initialize();
        }

        protected abstract void Initialize();

        public abstract void Handle();

        public void AddBarrier<T>() where T : IObject
        {
            BarrierList.Add(typeof(T));
        }

        public void RemoveBarrier<T>() where T : IObject
        {
            foreach (var type in BarrierList)
            {
                if (type.IsAssignableFrom(typeof(T)))
                {
                    BarrierList.Remove(type);
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
                        MotionState.Adjust(new Vector2(0, -1));
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Top.Contact)
                        MotionState.Adjust(new Vector2(0, 1));
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Left.Contact)
                        MotionState.Adjust(new Vector2(1, 0));
                    while (Detector.Detect(barrier, obj => obj.Solid, 0).Right.Contact)
                        MotionState.Adjust(new Vector2(-1, 0));
                }
            }
        }
    }
}