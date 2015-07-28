using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public HiddenBlockCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            var collision = Core.CollisionDetector.Detect<Mario>(mario => mario.GoingUp);
            if ((collision.BottomLeft | collision.BottomRight).Cover 
                || (collision.BottomLeft & collision.BottomRight).Touch
                || Core.CollisionDetector.Detect<SuperFireball>(fireball => !fireball.Exploded).AnyEdge.Touch)
            {
                Core.StateController.GiveThings(true);
            }
        }
    }
}
