using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class FireflowerCollisionHandler : CollisionHandlerKernelNew<FireflowerStateController>
    {

        public FireflowerCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            HandleMario();
            if (Core.StateController.MotionState.isGenerating)
            {
                HandleGeneration();
            }
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
                Core.StateController.MotionState.ObtainGravity();
                Core.BarrierHandler.AddBarrier<IBlock>();
            }
        }
    }
}
