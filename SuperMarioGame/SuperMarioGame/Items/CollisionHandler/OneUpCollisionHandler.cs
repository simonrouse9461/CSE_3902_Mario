﻿using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class OneUpCollisionHandler : CollisionHandlerKernel<OneUpStateController>
    {
        public OneUpCollisionHandler(ICore core) : base(core) { }

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
                Display.AddScore<OneUp>();
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
    }
}
