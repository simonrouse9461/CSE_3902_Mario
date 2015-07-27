using System;

namespace SuperMario
{
    public class GoombaStateController : EnemyStateControllerKernel<Goomba, GoombaSpriteState, GoombaMotionState>
    {
        public override void MarioSmash()
        {
            if (SpriteState.Dead) return;

            Core.DelayCommand(() =>
            {
                MotionState.MarioSmash();
                SpriteState.MarioSmash();
            });

            Core.DelayCommand(() => Core.Object.Unload(), 75);

            Display.AddScore<Goomba>();
            SoundManager.StompSoundPlay();
        }
    }
}