using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public NormalBlockCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (Core.StateController.giveCoin)
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
                    SoundManager.BlockBreakSoundPlay();
                }
            }
            else if(Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.giveCoin)
                {
                    Core.StateController.NormalBlockCoinHit();
                }
                else if(Core.StateController.giveStar)
                {
                    Core.StateController.NormalBlockGiveStar();
                }
            }
        }
    }
}