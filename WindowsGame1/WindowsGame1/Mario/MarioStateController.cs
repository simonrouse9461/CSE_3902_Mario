using System;

namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private bool dead;
        private bool WasOnFloor;

        private void CheckCeiling()
        {
            if ((BarrierCollision.TopLeft & BarrierCollision.TopRight).Touch) MotionState.Fall();
        }

        private void CheckFloor()
        {
            if (BarrierCollision.Bottom.Touch)
            {
                if (MotionState.Gravity) MotionState.LoseGravity();
                if (MotionState.DefaultHorizontal && !SpriteState.Crouching) SpriteState.Stand();
                if (!WasOnFloor)
                {
                    MotionState.Stop();
                    SpriteState.Run();
                }
                WasOnFloor = true;
            }
            else
            {
                MotionState.ObtainGravity();
                SpriteState.Jump();
                WasOnFloor = false;
            }
        }

        private void CheckDead()
        {
            if (dead)
            {
                SpriteState.BecomeDead();
                MotionState.Die();
            }
        }

        protected override void UpdateState()
        {
//            if (collision.Bottom.Touch && Core.Object.GoingDown) Core.GeneralMotionState.ResetVertical();
//            if (collision.Top.Touch && Core.Object.GoingUp) Core.GeneralMotionState.ResetVertical();
//            if (collision.Left.Touch && Core.Object.GoingLeft) Core.GeneralMotionState.ResetHorizontal();
//            if (collision.Right.Touch && Core.Object.GoingRight) Core.GeneralMotionState.ResetHorizontal();

            CheckCeiling();
            CheckFloor();
            CheckDead();
        }

        public void GoLeft()
        {
            if (SpriteState.Crouching) return;
            if (MotionState.HaveInertia) return;
            if (MotionState.Stopping && SpriteState.Left && SpriteState.Turning) return;

            SpriteState.ToLeft();

            if (MotionState.Velocity.X > 0)
            {
                MotionState.Stop();
                SpriteState.Turn();
            }
            else
            {
                MotionState.GoLeft();
                SpriteState.Run();
            }
        }

        public void GoRight()
        {
            if (SpriteState.Crouching) return;
            if (MotionState.HaveInertia) return;
            if (MotionState.Stopping && SpriteState.Right && SpriteState.Turning) return;
            
            SpriteState.ToRight();
            
            if (MotionState.Velocity.X < 0)
            {
                MotionState.Stop();
                SpriteState.Turn();
            }
            else
            {
                MotionState.GoRight();
                SpriteState.Run();
            }
        }

        public void KeepLeft()
        {
            if (SpriteState.Crouching) return;
            if (MotionState.HaveInertia)
            {
                SpriteState.ToLeft();
                MotionState.AdjustInertiaLeft();
            }
            else if (MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Left))
            {
                GoLeft();
            }
        }

        public void KeepRight()
        {
            if (SpriteState.Crouching) return;
            if (MotionState.HaveInertia)
            {
                SpriteState.ToRight();
                MotionState.AdjustInertiaRight();
            }
            else if (MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Right))
            {
                GoRight();
            }
        }

        public void StopMove()
        {
            if (MotionState.HaveInertia) return;
            MotionState.Stop();
        }

        public void Jump()
        {
            if (!MotionState.HaveInertia)
            {
                MotionState.GetInertia();
                MotionState.Jump();
                SpriteState.Jump();
            }
        }

        public void Fall()
        {
            MotionState.Fall();
        }

        public void Crouch()
        {
            SpriteState.Crouch();
            MotionState.Stop();
        }

        public void StopCrouch()
        {
            SpriteState.Stand();
        }

        public void Grow()
        {
            SpriteState.BecomeBig();
        }

        public void GetFire()
        {
            SpriteState.GetFire();
        }

        public void Die()
        {
            dead = true;
        }
    }
}