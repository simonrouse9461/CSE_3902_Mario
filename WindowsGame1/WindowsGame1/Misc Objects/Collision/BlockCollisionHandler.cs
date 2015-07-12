using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class BlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {
        public BlockCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (((QuestionBlockObject)Core.Object).giveItem)
                {
                    Core.StateController.QuestionBlockGiveFireflower();
                }
                else if (Core.StateController.SpriteState.isNormal)
                {
                    Core.StateController.NormalBlockDestroyed();
                }
                else if (((QuestionBlockObject)Core.Object).giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                }
                else if (((NormalBlockObject)Core.Object).giveCoin)
                {
                    Core.StateController.NormalBlockCoinHit();
                }
                else if (((HiddenBlockObject)Core.Object).giveOneUp)
                {
                    Core.StateController.HiddenBlockGive1Up();
                }
                else if (((HiddenBlockObject)Core.Object).giveStar)
                {
                    Core.StateController.NormalBlockGiveStar();
                }
            }
            else if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (((QuestionBlockObject)Core.Object).giveItem)
                {
                    Core.StateController.QuestionBlockGiveMushroom();
                }
                else if (((QuestionBlockObject)Core.Object).giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                }
                else if (((NormalBlockObject)Core.Object).giveCoin)
                {
                    Core.StateController.NormalBlockCoinHit();q
                }
                else if (((HiddenBlockObject)Core.Object).giveOneUp)
                {
                    Core.StateController.HiddenBlockGive1Up();
                }
                else if (((HiddenBlockObject)Core.Object).giveStar)
                {
                    Core.StateController.NormalBlockGiveStar();
                }
            }
        }
    }
}
