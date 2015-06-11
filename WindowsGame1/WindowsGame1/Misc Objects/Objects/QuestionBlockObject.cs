using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class QuestionBlockObject : ObjectKernel<QuestionBlockSpriteState, QuestionBlockMotionState>
    {

        public QuestionBlockObject(Vector2 location) : base(location) { }


        protected override void Initialize(Vector2 location)
        {
            SpriteState = new QuestionBlockSpriteState();
            MotionState = new QuestionBlockMotionState(location);
        }

        public void QuestionBlockAnimate(){
            SpriteState.Status = QuestionBlockSpriteState.StatusEnum.Animated;
        }
        public void QuestionToUsedBlock()
        {
            SpriteState.Status = QuestionBlockSpriteState.StatusEnum.UsedBlock;
        }
    }
}
