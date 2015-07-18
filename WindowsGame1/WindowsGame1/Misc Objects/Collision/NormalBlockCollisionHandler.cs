using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernel<BlockStateController>
    {

        public NormalBlockCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (Core.StateController.giveCoin && !Core.StateController.SpriteState.isUsed)
                {
                    Core.StateController.NormalBlockCoinHit();
                }
                else if (Core.StateController.giveStar)
                {
                    Core.StateController.NormalBlockGiveStar();
                }
                else
                {
                    Core.StateController.NormalBlockDestroyed();
                    SoundManager.blockBreakSoundPlay();
                }
            }
            else if(Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.giveCoin && !Core.StateController.SpriteState.isUsed)
                {
                    Core.StateController.NormalBlockCoinHit();
                }
                else if(Core.StateController.giveStar)
                {
                 
                    Core.StateController.NormalBlockGiveStar();
                }
                else if (Core.StateController.SpriteState.isNormal)
                {
                    Core.StateController.MotionState.Hit();
                }
            }
        }
    }
}