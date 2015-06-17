using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class QuestionBlockObject : ObjectKernelNew<QuestionBlockSpriteState, QuestionBlockMotionState>
    {

        public QuestionBlockObject(WorldManager world) : base(world) { }


        protected override void Initialize()
        {
            SpriteState = new QuestionBlockSpriteState();
            MotionState = new QuestionBlockMotionState();
            CollisionHandler = new QuestionBlockCollisionHandler(SpriteState, MotionState, this);
        }

        public void QuestionBlockAnimate(){
            SpriteState.Status = QuestionBlockSpriteState.StatusEnum.Animated;
        }
        public void QuestionToUsedBlock()
        {
            SpriteState.Status = QuestionBlockSpriteState.StatusEnum.UsedBlock;
        }

        protected override void SyncState()
        {

        }
    }
}
