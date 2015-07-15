﻿using System;

namespace WindowsGame1
{
    public class KoopaStateController : StateControllerKernel<KoopaSpriteState, KoopaMotionState>
    {
        public void Update()
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
            MotionState.TakeMarioHitFromSide(leftOrRight);
        }

        public void Turn()
        {
            SpriteState.Turn();
            MotionState.Turn();
        }
    }
}