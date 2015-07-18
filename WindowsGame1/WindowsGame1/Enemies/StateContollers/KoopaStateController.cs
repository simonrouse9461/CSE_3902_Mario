﻿using System;

namespace WindowsGame1
{
    public class KoopaStateController : StateControllerKernel<KoopaSpriteState, KoopaMotionState>
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
            SoundManager.stompSoundPlay();
        }

        public void TakeMarioHitFromSide(string leftOrRight)
        {
            MotionState.TakeMarioHitFromSide(leftOrRight);
        }

        public void Turn(String leftOrRight)
        {
            if (leftOrRight.Equals("left"))
            {
                MotionState.Turn(leftOrRight);
            }
            else if (leftOrRight.Equals("right"))
            {
                MotionState.Turn(leftOrRight);
            }
            else
            {
                throw new System.ArgumentException("Parameter must be \"left\" or \"right\".", "leftOrRight");
            }
            SpriteState.Turn();
        }
    }
}