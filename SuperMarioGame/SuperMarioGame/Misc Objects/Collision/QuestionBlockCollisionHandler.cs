using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {
        public QuestionBlockCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp && !mario.Destructive).Bottom.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion)
                {
                    Core.StateController.GiveThings(false);
                }
            }
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp && mario.Destructive).Bottom.Touch 
                || Core.CollisionDetector.Detect<SuperFireballObject>().AnyEdge.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion)
                {
                    Core.StateController.GiveThings(true);
                }
            }
        }
    }
}
