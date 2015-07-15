﻿using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public QuestionBlockCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                }
                else if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveItem)
                {
                    Core.StateController.QuestionBlockGiveFireflower();
                }
            }
            else if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveItem)
                {
                    Core.StateController.QuestionBlockGiveMushroom();
                }
                else if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                }
            }
        }
    }
}