using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernelNew<QuestionBlockSpriteState, QuestionBlockMotionState>
    {

        public QuestionBlockCollisionHandler(State<QuestionBlockSpriteState,QuestionBlockMotionState> state) : base(state) 
        {
            AddBarrier<IObject>();
        }

        public override void Handle(){
            if(Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Contact){
                State.SpriteState.UsedBlock();
            }
        }
    }
}
