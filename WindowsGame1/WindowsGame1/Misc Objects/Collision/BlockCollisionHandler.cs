using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class BlockCollisionHandler : CollisionHandlerKernel<BlockSpriteState, BlockMotionState>
    {
        public BlockCollisionHandler(Core<BlockSpriteState, BlockMotionState> core) : base(core){}

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if(Core.SpriteState.isQuestionBlock){
                    Core.SpriteState.QuestionToUsedBlock();
                }
                if (Core.SpriteState.isNormal && Detector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
                {
                    Core.Object.Unload();
                }
                if (Core.SpriteState.isHidden)
                {
                    Core.SpriteState.HiddenToUsedBlock();
                }
                if (Core.SpriteState.isDestructible)
                {
                    Core.Object.Unload();
                }
            }
        }
    }
}
