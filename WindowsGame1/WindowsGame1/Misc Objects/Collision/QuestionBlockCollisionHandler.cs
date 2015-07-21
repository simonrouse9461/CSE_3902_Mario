using System;
using System.Collections.Generic;

namespace MarioGame
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public QuestionBlockCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                    Display.AddScore<Coin>();
                }
                else if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveItem)
                {
                    Core.StateController.QuestionBlockGiveFireflower();
                }
            }
            else if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveItem)
                {
                    Core.StateController.QuestionBlockGiveMushroom();
                }
                else if (Core.StateController.SpriteState.isQuestion && Core.StateController.giveCoin)
                {
                    Core.StateController.QuestionBlockGiveCoin();
                    Display.AddScore<Coin>();
                }
            }
        }
    }
}
