﻿using System;

namespace WindowsGame1
{
    public class GoombaStateController : StateControllerKernel<GoombaSpriteState, GoombaMotionState>
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

        protected override void UpdateState()
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