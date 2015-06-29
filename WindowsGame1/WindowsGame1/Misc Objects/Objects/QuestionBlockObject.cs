using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class QuestionBlockObject : ObjectKernel<QuestionBlockSpriteState, QuestionBlockMotionState>
    {

        public QuestionBlockObject() { 
            SpriteState = new QuestionBlockSpriteState();
            MotionState = new QuestionBlockMotionState();
            CollisionHandler = new QuestionBlockCollisionHandler(Core);
        }

        //public void QuestionBlockAnimate(){
        //    SpriteState.Status = QuestionBlockSpriteState.StatusEnum.Animated;
        //}
        //public void QuestionToUsedBlock()
        //{
        //    SpriteState.Status = QuestionBlockSpriteState.StatusEnum.UsedBlock;
        //}

        protected override void SyncState()
        {

        }
    }
}
