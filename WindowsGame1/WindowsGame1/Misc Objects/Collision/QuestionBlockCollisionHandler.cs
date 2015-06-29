using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernel<QuestionBlockSpriteState, QuestionBlockMotionState>
    {
        public QuestionBlockCollisionHandler(State<QuestionBlockSpriteState,QuestionBlockMotionState> state) : base(state) { }

        public override void Handle(){
            if(Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch){
                State.SpriteState.UsedBlock();
            }
        }
    }
}
