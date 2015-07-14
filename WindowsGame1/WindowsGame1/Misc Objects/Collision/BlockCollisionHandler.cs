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
                if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveItem)
                {
                    Core.StateController.QuestionBlockGiveFireflower();
                }
                else if (Core.StateController.SpriteState.isNormal)
                {
                    Core.StateController.NormalBlockDestroyed();
                    SoundManager.BlockBreakSoundPlay();
                }
                else if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                }
                else if (Core.StateController.SpriteState.isNormal && Core.StateController.giveCoin)
                {
                    Core.StateController.NormalBlockCoinHit();
                }
                else if (Core.StateController.SpriteState.isHidden && Core.StateController.giveOneUp)
                {
                    Core.StateController.HiddenBlockGive1Up();
                }
                else if (Core.StateController.SpriteState.isHidden && Core.StateController.giveStar)
                {
                    Core.StateController.NormalBlockGiveStar();
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
                else if (Core.StateController.SpriteState.isNormal && Core.StateController.giveCoin)
                {
                    Core.StateController.NormalBlockCoinHit();
                }
                else if (Core.StateController.SpriteState.isHidden && Core.StateController.giveOneUp)
                {
                    Core.StateController.HiddenBlockGive1Up();
                }
                else if (Core.StateController.SpriteState.isHidden && Core.StateController.giveStar)
                {
                    Core.StateController.NormalBlockGiveStar();
                }
            }
        }
    }
}
