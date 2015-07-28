using System;

namespace SuperMario
{
    public class GoombaStateController : EnemyStateControllerKernel<Goomba, GoombaSpriteState, GoombaMotionState>
    {
        public override void MarioSmash()
        {
            if (SpriteState.Dead) return;

            MotionState.MarioSmash();
            SpriteState.MarioSmash();
            Core.DelayCommand(() => Core.Object.Unload(), 75);
            Core.Object.TurnUnsolid();
            Core.BarrierHandler.ClearBarrier();
            Display.AddScore<Goomba>();
            SoundManager.StompSoundPlay();
        }
    }
}