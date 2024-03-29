﻿using System;

namespace SuperMario
{
    public class KoopaStateController : EnemyStateControllerKernel<Koopa, KoopaSpriteState, KoopaMotionState>
    {
        public override void MarioSmash()
        {
            MotionState.MarioSmash();
            SpriteState.TurnShell();

            Core.SwitchComponent(new MovingShellCollisionHandlerDecorator(Core));
            Core.DelayCommand(() =>
            {
                SpriteState.Restore();
                SpriteState.HoldTillFinish(true, () =>
                {
                    ((IDecorator)Core.CollisionHandler).Restore();
                });
            }, () => NotMoving, 200);
            SoundManager.StompSoundPlay();
        }

        public void PushShell(Orientation orientation)
        {
            if (!NotMoving) return;
            SoundManager.KickSoundPlay();
            SpriteState.Release();
            SpriteState.TurnShell();
            MotionState.Push(orientation);
        }

        public void Walk()
        {
            SpriteState.Walk();
            MotionState.Turn(SpriteState.Orientation);
        }
    }
}