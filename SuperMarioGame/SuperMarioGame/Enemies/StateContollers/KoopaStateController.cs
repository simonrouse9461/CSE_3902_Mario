using System;

namespace SuperMario
{
    public class KoopaStateController : EnemyStateControllerKernel<Koopa, KoopaSpriteState, KoopaMotionState>
    {
        public override void MarioSmash()
        {
            MotionState.MarioSmash();
            SpriteState.MarioSmash();

            Core.SwitchComponent(new MovingShellCollisionHandlerDecorator(Core));
            ((IDecorator) Core.CollisionHandler).DelayRestore(150);
            SoundManager.StompSoundPlay();
        }

        public void PushShell(Orientation orientation)
        {
            if (!NotMoving) return;
            SoundManager.KickSoundPlay();
            MotionState.Push(orientation);
        }

        public void Walk()
        {
            SpriteState.Walk();
            MotionState.Turn(SpriteState.Orientation);
        }
    }
}