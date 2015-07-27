using System;

namespace SuperMario
{
    public class GoombaStateController : StateControllerKernelNew<GoombaSpriteState, GoombaMotionState>
    {
        public void MarioSmash()
        {
            Core.DelayCommand(() =>
            {
                MotionState.MarioSmash();
                SpriteState.MarioSmash();
            });

            Core.DelayCommand(() =>
            {
                Core.Object.Unload();
            }, 75);

            Display.AddScore<Goomba>();
            SoundManager.StompSoundPlay();
        }

        public void Flip()
        {
            if (SpriteState.Dead) return;

            SoundManager.KickSoundPlay();
            MotionState.Flip();
            SpriteState.Flip();

            Display.AddScore<Goomba>();
        }

        public void Turn(Orientation orientation = Orientation.Default)
        {
            MotionState.Turn(orientation);
        }
    }
}