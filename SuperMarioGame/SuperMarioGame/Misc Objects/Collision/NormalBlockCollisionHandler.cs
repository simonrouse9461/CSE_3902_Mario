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
            var destructiveCollision = Core.CollisionDetector.Detect<Mario>(mario => mario.Destructive);
            var generalCollision = Core.CollisionDetector.Detect<Mario>(mario => mario.GoingUp);
            if ((destructiveCollision.BottomLeft | destructiveCollision.BottomRight).Cover
                || (destructiveCollision.BottomLeft & destructiveCollision.BottomRight).Touch)
            {
                if (!Core.StateController.HasStar && !Core.StateController.HasCoin)
                    Core.StateController.NormalBlockDestroyed();
            }
            if ((generalCollision.BottomLeft | generalCollision.BottomRight).Cover
                || (generalCollision.BottomLeft & generalCollision.BottomRight).Touch)
            {
                if (Core.StateController.HasCoin || Core.StateController.SpriteState.isNormal && !Core.StateController.HasStar)
                    Core.StateController.GotHit();
                if (Core.StateController.HasStar || Core.StateController.HasCoin)
                    Core.StateController.GiveThings(true);
            }
        }

        private void HandleSuperFireball()
        {
            if (Core.CollisionDetector.Detect<SuperFireball>(fireball => !fireball.Exploded).AnyEdge.Touch)
            {
                if (Core.StateController.HasStar || Core.StateController.HasCoin)
                    Core.StateController.GiveThings(true);
                else Core.StateController.NormalBlockDestroyed();
            }
        }
    }
}