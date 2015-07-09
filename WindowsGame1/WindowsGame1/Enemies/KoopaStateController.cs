﻿using System;

namespace WindowsGame1
{
    public class KoopaStateController : StateControllerKernel<KoopaSpriteState, KoopaMotionState>
    {
        private Collision collision;

        private void CheckFloor()
        {
            if (!collision.Bottom.Touch)
            {
                MotionState.ObtainGravity();
            }
            else
            {
                MotionState.LoseGravity();
            }
        }

        public override void Update()
        {
            collision = Core.CollisionDetector.Detect<IBlock>();
            CheckFloor();
        }

        public void MarioSmash()
        {
            MotionState.MarioSmash();
            SpriteState.MarioSmash();
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