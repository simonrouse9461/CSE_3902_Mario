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

            HandleMario();
            HandleSuperFireball();
        }

        private void HandleMario()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                if (!Core.StateController.HasStar && !Core.StateController.HasCoin)
                    Core.StateController.NormalBlockDestroyed();
            }
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                if (Core.StateController.HasCoin || Core.StateController.SpriteState.isNormal && !Core.StateController.HasStar)
                    Core.StateController.GotHit();
                if (Core.StateController.HasStar || Core.StateController.HasCoin)
                    Core.StateController.GiveThings(true);
            }
        }

        private void HandleSuperFireball()
        {
            if (Core.CollisionDetector.Detect<SuperFireballObject>().AnyEdge.Touch)
            {
                if (Core.StateController.HasStar || Core.StateController.HasCoin)
                    Core.StateController.GiveThings(true);
                else Core.StateController.NormalBlockDestroyed();
            }
        }
    }
}