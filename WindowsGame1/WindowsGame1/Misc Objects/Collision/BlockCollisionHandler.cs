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
                    Core.SpriteState.Destroyed();
                    Core.DelayCommand(() => Core.Object.Unload(), 12);
                }
                if (Core.SpriteState.isHidden)
                {
                    Core.SpriteState.HiddenToUsedBlock();
                }
            }
        }
    }
}
