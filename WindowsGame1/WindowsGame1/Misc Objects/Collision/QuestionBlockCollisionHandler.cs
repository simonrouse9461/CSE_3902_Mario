using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernel<QuestionBlockSpriteState, QuestionBlockMotionState>
    {
        public QuestionBlockCollisionHandler(Core<QuestionBlockSpriteState,QuestionBlockMotionState> core) : base(core) { }

        public override void Handle(){
            if(Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch){
                Core.SpriteState.UsedBlock();
            }
        }
    }
}
