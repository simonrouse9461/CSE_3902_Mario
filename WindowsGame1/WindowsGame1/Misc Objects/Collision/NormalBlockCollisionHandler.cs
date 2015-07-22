using System;
using System.Collections.Generic;

namespace MarioGame
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public NormalBlockCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (Core.StateController.giveCoin && !Core.StateController.SpriteState.isUsed)
                {
                    Core.StateController.NormalBlockCoinHit();
                    Core.StateController.MotionState.Hit();
                    Display.AddScore<Coin>();
                }
                else if (Core.StateController.giveStar && !Core.StateController.SpriteState.isUsed)
                {
                    Core.StateController.NormalBlockGiveStar();
                    Display.AddScore<Star>();
                }
                else if(!Core.StateController.SpriteState.isUsed)
                {
                    Core.StateController.NormalBlockDestroyed();
                    SoundManager.BlockBreakSoundPlay();
                }
            }
            else if(Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.giveCoin && !Core.StateController.SpriteState.isUsed)
                {
                    Core.StateController.NormalBlockCoinHit();
                    Core.StateController.MotionState.Hit();
                    Display.AddScore<Coin>();
                }
                else if(Core.StateController.giveStar && !Core.StateController.SpriteState.isUsed)
                {
                 
                    Core.StateController.NormalBlockGiveStar();
                    Display.AddScore<Star>();
                }
                else if (Core.StateController.SpriteState.isNormal)
                {
                    Core.StateController.MotionState.Hit();
                    
                }
            }
        }
    }
}