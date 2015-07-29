using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class QuestionBlockCollisionHandler : CollisionHandlerKernel<BlockStateController>
    {
        public QuestionBlockCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            var smallMario = Core.CollisionDetector.Detect<Mario>(mario => mario.GoingUp && !mario.Destructive);
            var destructiveMario = Core.CollisionDetector.Detect<Mario>(mario => mario.GoingUp && mario.Destructive);
            if ((smallMario.BottomLeft | smallMario.BottomRight).Cover 
                || (smallMario.BottomLeft & smallMario.BottomRight).Touch)
            {
                if (Core.StateController.SpriteState.isQuestion)
                {
                    Core.StateController.GiveThings(false);
                }
            }
            if ((destructiveMario.BottomLeft | destructiveMario.BottomRight).Cover 
                || (destructiveMario.BottomLeft & destructiveMario.BottomRight).Touch
                || Core.CollisionDetector.Detect<SuperFireball>(fireball => !fireball.Exploded).AnyEdge.Touch)
            {
                if (Core.StateController.SpriteState.isQuestion)
                {
                    Core.StateController.GiveThings(true);
                }
            }
        }
    }
}
