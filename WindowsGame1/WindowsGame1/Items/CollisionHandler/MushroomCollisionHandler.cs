using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MushroomCollisionHandler : CollisionHandlerKernelNew<MushroomStateController>
    {

        public MushroomCollisionHandler(ICore core) : base(core){ }

        public override void Handle()
        {
            HandleMario();
            if (Core.StateController.MotionState.isGenerating)
            {
                HandleGeneration();
            }
            HandleObject();
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<MarioObject>().AnySide.Touch)
            {
                Core.Object.Unload();
                Display.AddScore<Mushroom>();
            }
        }

        protected virtual void HandleGeneration()
        {

            if (Core.CollisionDetector.Detect<IBlock>().AllEdge.None)
            {
                Core.StateController.MotionState.Moving();
                Core.BarrierHandler.AddBarrier<IBlock>();
                Core.BarrierHandler.AddBarrier<IPipe>();
            }
        }

        protected virtual void HandleObject()
        {
            if (Core.CollisionDetector.Detect<IBlock>().BothSide.Touch || Core.CollisionDetector.Detect<IPipe>().BothSide.Touch)
            {
                Core.StateController.MotionState.ChangeDirection();
            }
        }
    }
}
