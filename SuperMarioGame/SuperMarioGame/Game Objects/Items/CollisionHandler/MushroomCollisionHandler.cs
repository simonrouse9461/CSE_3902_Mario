using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class MushroomCollisionHandler : CollisionHandlerKernel<MushroomStateController>
    {
        public MushroomCollisionHandler(ICore core) : base(core){ }

        public override void Handle()
        {
            HandleMario();
            if (Core.StateController.MotionState.IsGenerating)
            {
                HandleGeneration();
            }
            if (!Core.StateController.MotionState.IsGenerating)
            {
                HandleObject();
            }
            HandleBlock();
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<Mario>().AnySide.Touch)
            {
                Core.Object.Unload();
                Display.AddScore<Mushroom>();
            }
        }

        protected virtual void HandleGeneration()
        {

            if (Core.CollisionDetector.Detect<IBlock>().AllEdge.None)
            {
                Core.BarrierHandler.AddBarrier<IBlock>();
                Core.BarrierHandler.AddBarrier<IPipe>();
                Core.StateController.MotionState.Moving();
            }
        }

        protected virtual void HandleObject()
        {
            if (Core.CollisionDetector.Detect<IBlock>().BothSide.Touch || Core.CollisionDetector.Detect<IPipe>().BothSide.Touch)
            {
                Core.StateController.MotionState.ChangeDirection();
            }
        }

        protected virtual void HandleBlock()
        {
            if (Core.CollisionDetector.Detect<IBlock>(block => block.Hit).Bottom.Touch)
            {
                Core.StateController.MotionState.ChangeDirection();
            }
        }
    }
}
