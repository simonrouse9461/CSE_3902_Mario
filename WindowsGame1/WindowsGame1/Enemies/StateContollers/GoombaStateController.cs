using System;

namespace WindowsGame1
{
    public class GoombaStateController : StateControllerKernel<GoombaSpriteState, GoombaMotionState>
    {
        public override void Update()
        {
            if (!MotionState.isAlive())
            {
                Core.DelayCommand(() =>
                    {
                        Core.Object.Unload();
                    }, 75);
            }
        }

        public void MarioSmash()
        {
            Core.DelayCommand(() =>
            {
                MotionState.MarioSmash();
                SpriteState.MarioSmash();
            });

            Display.AddScore<Goomba>();
            SoundManager.stompSoundPlay();
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