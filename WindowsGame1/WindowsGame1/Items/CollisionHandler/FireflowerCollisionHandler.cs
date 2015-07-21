using System;
using System.Collections.Generic;

namespace MarioGame
{
    public class FireflowerCollisionHandler : CollisionHandlerKernel<FireflowerStateController>
    {

        public FireflowerCollisionHandler(ICore core) : base(core) { }

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
                Core.BarrierHandler.AddBarrier<IBlock>();
                Core.StateController.MotionState.SetDefaultVertical();
            }
        }
        
        protected virtual void HandleObject()
        {
            if (Core.CollisionDetector.Detect<IBlock>().Bottom.Touch)
            {
                Core.StateController.MotionState.LoseGravity();
            }
        }
    }
}
