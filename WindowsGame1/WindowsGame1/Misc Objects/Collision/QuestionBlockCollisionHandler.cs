using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernel<QuestionBlockSpriteState, QuestionBlockMotionState>
    {
        private CollisionDetector<MarioObject> MarioQuestionBlockCollision;

        public QuestionBlockCollisionHandler(QuestionBlockSpriteState spriteState, QuestionBlockMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize() {
            MarioQuestionBlockCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle(){
            if(MarioQuestionBlockCollision.Detect().Bottom){
                SpriteState.UsedBlock();
            }
        }
    }
}
