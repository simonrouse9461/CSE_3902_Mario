using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class EnemyCollisionHandler : CollisionHandlerKernel<EnemySpriteState, EnemyMotionState>
    {
        public EnemyCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.Alive && mario.GoingDown).Top.Touch)
            {
                Core.SpriteState.MarioSmash();
            }
        }
    }
}