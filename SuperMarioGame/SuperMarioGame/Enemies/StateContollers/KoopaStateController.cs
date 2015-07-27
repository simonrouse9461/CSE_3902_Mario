using System;

namespace SuperMario
{
    public class KoopaStateController : StateControllerKernelNew<KoopaSpriteState, KoopaMotionState>
    {
        public override void Update()
        {
        }

        public void MarioSmash()
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

        public void Turn()
        {
            SoundManager.KickSoundPlay();
            MotionState.Turn(Orientation.Default);
            SpriteState.Turn();
        }

        public void Flip()
        {
            if (SpriteState.Dead) return;
            SoundManager.KickSoundPlay();
            SpriteState.Flip();
            MotionState.Flip();
        }
    }
}