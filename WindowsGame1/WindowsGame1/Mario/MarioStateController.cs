using System;

namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private Collision collision;
        private bool dead;
        private bool WasOnFloor;

        private void CheckWall()
        {
            if (collision.AnySide.Touch && MotionState.HaveInertia) MotionState.ResetInertia();
        }

        private void CheckCeiling()
        {
            if ((collision.TopLeft & collision.TopRight).Touch) MotionState.Fall();
        }

        private void CheckFloor()
        {
            if (collision.Bottom.Touch)
            {
                if (MotionState.Gravity) MotionState.LoseGravity();
                if (MotionState.DefaultHorizontal) SpriteState.Stand();
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
            collision = Core.CollisionDetector.Detect<IObject>(obj => obj.Solid);
            CheckWall();
            CheckCeiling();
            CheckFloor();
            CheckDead();
        }

        public void GoLeft()
        {
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
        }

        public void StopCrouch()
        {
            
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