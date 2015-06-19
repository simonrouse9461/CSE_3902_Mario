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
        protected CollisionDetectorNew CollisionDetector { get; private set; }
        public bool Solid { get; set; }

        private readonly Collection<Type> BarrierList;

        protected CollisionHandlerKernelNew(TSpriteState spriteState, TMotionState motionState, IObject obj)
        {
            SpriteState = spriteState;
            MotionState = motionState;
            Object = obj;
            Solid = true;
            CollisionDetector = new CollisionDetectorNew(Object);
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
            Type temp = null;
            foreach (var type in BarrierList)
            {
                if (Activator.CreateInstance(type) is T)
                {
                    temp = type;
                }
            }
            if (temp != null)
                BarrierList.Remove(temp);
        }

        public void DetectBarrier()
        {
            foreach (var barrier in BarrierList)
            {
                if (CollisionDetector.Detect(barrier).Any())
                {
                    while (CollisionDetector.Detect(barrier, obj => obj.Solid, 0).Bottom)
                        MotionState.Adjust(new Vector2(0, -1));
                    while (CollisionDetector.Detect(barrier, obj => obj.Solid, 0).Top)
                        MotionState.Adjust(new Vector2(0, 1));
                    while (CollisionDetector.Detect(barrier, obj => obj.Solid, 0).Left)
                        MotionState.Adjust(new Vector2(1, 0));
                    while (CollisionDetector.Detect(barrier, obj => obj.Solid, 0).Right)
                        MotionState.Adjust(new Vector2(-1, 0));
                }
            }
        }
    }
}