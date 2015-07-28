using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class StarCollisionHandler : CollisionHandlerKernel<StarStateController>
    {

        public StarCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            HandleMario();
            if (Core.StateController.MotionState.isGenerating)
            {
                HandleGeneration();
            }
            if (!Core.StateController.MotionState.isGenerating)
            {
                HandleObject();
            }
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<Mario>().AnySide.Touch)
            {
                Core.Obj.Unload();
                Display.AddScore<Star>();
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
            if (Core.CollisionDetector.Detect<IBlock>().AnySide.Touch || Core.CollisionDetector.Detect<IPipe>().AnySide.Touch)
            {
                Core.StateController.MotionState.ChangeDirection();
            }
            if (Core.CollisionDetector.Detect<IBlock>().Top.Touch)
            {
                Core.StateController.MotionState.SetDefaultVertical();
            }
        }
    }
}
