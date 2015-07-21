using System;

namespace WindowsGame1
{
    public class GoombaStateController : StateControllerKernel<GoombaSpriteState, GoombaMotionState>
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

            Core.DelayCommand(() =>
            {
                Core.Object.Unload();
            }, 75);

            Display.AddScore<Goomba>();
            SoundManager.StompSoundPlay();
        }

        public void Flip()
        {
            MotionState.Flip();
            SpriteState.Flip();

            Core.DelayCommand(() =>
            {
                Core.Object.Unload();
            }, 30);

            Display.AddScore<Goomba>();
            SoundManager.StompSoundPlay();
        }

        public void TakeMarioHitFromSide(string leftOrRight)
        {
            MotionState.TakeMarioHitFromSide(leftOrRight);
        }

        public void Turn()
        {
            MotionState.Turn();
        }
    }
}