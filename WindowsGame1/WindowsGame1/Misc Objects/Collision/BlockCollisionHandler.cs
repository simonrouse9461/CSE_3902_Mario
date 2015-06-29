using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class BlockCollisionHandler : CollisionHandlerKernelNew<BlockSpriteState, BlockMotionState>
    {


        public BlockCollisionHandler(State<BlockSpriteState, BlockMotionState> state)
            : base(state)
        {
            AddBarrier<IObject>();
        }


        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Contact)
            {
                if(State.SpriteState.isQuestionBlock){
                    State.SpriteState.QuestionToUsedBlock();
                }
                if (State.SpriteState.isNormal && Detector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Contact)
                {
                    State.Object.Unload();
                }
                if (State.SpriteState.isHidden)
                {
                    State.SpriteState.HiddenToUsedBlock();
                }
                if (State.SpriteState.isDestructible)
                {
                    State.Object.Unload();
                }
            }
        }
    }
}
