using System;

namespace SuperMario
{
    public class KoopaStateController : EnemyStateControllerKernel<Koopa, KoopaSpriteState, KoopaMotionState>
    {
        public override void MarioSmash()
        {
            Core.DelayCommand(() =>
            {
                MotionState.MarioSmash();
                SpriteState.MarioSmash();
            });

            Display.AddScore<Koopa>();
            SoundManager.StompSoundPlay();
        }

        public void TakeMarioHitFromSide(Orientation orientation)
        {
            SoundManager.KickSoundPlay();
            MotionState.GotHit(orientation);
        }
    }
}