using System;

namespace SuperMario
{
    public class GoombaStateController : EnemyStateControllerKernel<Goomba, GoombaSpriteState, GoombaMotionState>
    {
        public override void MarioSmash()
        {
            if (SpriteState.Dead) return;

            MotionState.MarioSmash();
            SpriteState.Squash();
            Core.DelayCommand(() => Core.Object.Unload(), 75);
            Core.BarrierHandler.BecomeNonBarrier();
            Core.BarrierHandler.ClearBarrier();
            Display.AddScore<Goomba>();
            SoundManager.StompSoundPlay();
        }
    }
}