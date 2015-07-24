﻿using System;

namespace SuperMario
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
            SoundManager.StompSoundPlay();
        }

        public void TakeMarioHitFromSide(string leftOrRight)
        {
            SoundManager.KickSoundPlay();
            MotionState.TakeMarioHitFromSide(leftOrRight);
        }

        public void Turn(String leftOrRight)
        {
            SoundManager.KickSoundPlay();
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

        public void Flip()
        {
            SoundManager.KickSoundPlay();
            SpriteState.Flip();
            MotionState.Flip();
        }
    }
}