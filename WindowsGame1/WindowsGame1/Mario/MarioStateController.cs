using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private bool dead;
        private bool WasOnFloor;
        private const int MagazineCapacity = 2;
        private int AmmoLeft = 2;
        private Counter ReloadTimer;

        private void CheckCeiling()
        {
            if (SpriteState.Dead) return;
            if ((BarrierCollision.TopLeft & BarrierCollision.TopRight).Touch) MotionState.Fall();
        }

        private void CheckFloor()
        {
            if (SpriteState.Dead) return;
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
                MotionState.GetInertia();
                SpriteState.Jump();
                WasOnFloor = false;
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
        }

        public void GoLeft()
        {
            if (SpriteState.Dead) return;
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
            if (SpriteState.Dead) return;
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
            if (SpriteState.Dead) return;
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
            if (SpriteState.Dead) return;
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
            if (SpriteState.Dead) return;
            if (MotionState.HaveInertia) return;
            MotionState.Stop();
        }

        public void Jump()
        {
            if (SpriteState.Dead) return;
            if (!MotionState.HaveInertia)
            {
                MotionState.Jump();
                SpriteState.Jump();
            }
        }

        public void Fall()
        {
            if (SpriteState.Dead) return;
            MotionState.Fall();
        }

        public void Crouch()
        {
            if (SpriteState.Dead) return;
            SpriteState.Crouch();
            MotionState.Stop();
        }

        public void StopCrouch()
        {
            if (SpriteState.Dead) return;
            SpriteState.Stand();
        }

        public void Grow()
        {
            if (SpriteState.Dead) return;
            SpriteState.BecomeBig();
        }

        public void GetFire()
        {
            if (SpriteState.Dead) return;
            SpriteState.GetFire();
        }

        public void Die()
        {
            if (SpriteState.Dead) return;
            SpriteState.BecomeDead();
            MotionState.Die();
            WorldManager.Instance.FreezeWorld();
        }

        public void Shoot()
        {
            if (SpriteState.Dead) return;
            SpriteState.Shoot();
            Core.Object.Generate(
                new Vector2(SpriteState.Left ? -10 : 10, -20),
                SpriteState.Left ? new FireballObject().LeftFireBall : new FireballObject().RightFireBall
                );
        }
    }
}