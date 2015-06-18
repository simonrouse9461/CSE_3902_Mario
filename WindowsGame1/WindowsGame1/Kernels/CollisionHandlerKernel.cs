using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TSpriteState, TMotionState> : ICollisionHandler
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected IObject Object { get; set; }
        protected TSpriteState SpriteState { get; set; }
        protected TMotionState MotionState { get; set; }

        private readonly Collection<ICollisionDetector> BarrierList;

        protected CollisionHandlerKernel(TSpriteState spriteState, TMotionState motionState, IObject obj)
        {
            SpriteState = spriteState;
            MotionState = motionState;
            Object = obj;
            BarrierList = new Collection<ICollisionDetector>();
            Initialize();
        }

        protected abstract void Initialize();

        public abstract void Handle();

        public void AddBarrier<T>() where T : IObject
        {
            BarrierList.Add(new CollisionDetector<T>(Object));
        }

        public void RemoveBarrier<T>() where T : IObject
        {
            ICollisionDetector temp = null;
            foreach (var barrier in BarrierList)
            {
                if (barrier is CollisionDetector<T>)
                {
                    temp = barrier;
                }
            }
            if (temp != null)
                BarrierList.Remove(temp);
        }

        public void DetectBarrier()
        {
            foreach (var barrier in BarrierList)
            {
                if (barrier.Detect().Any())
                {
                    while (barrier.Detect(0).Bottom)
                    {
                        MotionState.Adjust(new Vector2(0, -1));
                    }
                    while (barrier.Detect(0).Top)
                    {
                        MotionState.Adjust(new Vector2(0, 1));
                    }
                    while (barrier.Detect(0).Left)
                    {
                        MotionState.Adjust(new Vector2(1, 0));
                    }
                    while (barrier.Detect(0).Right)
                    {
                        MotionState.Adjust(new Vector2(-1, 0));
                    }
                }
            }
        }
    }
}