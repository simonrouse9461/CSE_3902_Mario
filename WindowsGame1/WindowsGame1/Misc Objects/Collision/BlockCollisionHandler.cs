using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class BlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {
        public BlockCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if(Core.StateController.SpriteState.isQuestionBlock){
                    Core.StateController.SpriteState.QuestionToUsedBlock();
                }
                
                if (Core.StateController.SpriteState.isNormal && Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
                {
                    Core.StateController.SpriteState.Destroyed();
                    Core.DelayCommand(() => Core.Object.Unload(), 12);
                }
                if (Core.StateController.SpriteState.isHidden)
                {
                    Core.StateController.SpriteState.HiddenToUsedBlock();
                }
            }
        }
    }
}
