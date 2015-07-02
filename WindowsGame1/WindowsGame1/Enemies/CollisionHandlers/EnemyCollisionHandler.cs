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
                Core.MotionState.MarioSmash();
                //Core.Object.Transform<Goomba>();
                //Core.DelayCommand(() => Core.Object.Unload());
            }

            if (Detector.Detect<FireballObject>().AnyEdge.Touch || Detector.Detect<Koopa>(koopa => koopa.isMovingShell).AnySide.Touch)
            {
                Core.SpriteState.MarioSmash();
                Core.MotionState.Die();
            }

            if (Detector.Detect<IBlock>().AnySide.Touch || Detector.Detect<GreenPipeObject>().AnySide.Touch) {
                Core.MotionState.Turn();
                Core.SpriteState.Turn();
            }
        }
    }
}