using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public NormalBlockCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            if (Core.StateController.SpriteState.isUsed) return;

            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch
                || Core.CollisionDetector.Detect<SuperFireballObject>().AnyEdge.Touch)
            {
                if (!Core.StateController.HasStar && !Core.StateController.HasCoin)
                    Core.StateController.NormalBlockDestroyed();
                else Core.StateController.GiveThings(true);
            }
            
            if(Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.HasCoin || Core.StateController.SpriteState.isNormal)
                    Core.StateController.MotionState.Hit();
            }
        }
    }
}