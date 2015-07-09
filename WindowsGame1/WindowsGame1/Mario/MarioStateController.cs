using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private bool WasOnFloor;
        private const int MagazineCapacity = 2;
        private Counter ReloadTimer;

        private int _ammoLeft = 2;
        private int AmmoLeft
        {
            get { return _ammoLeft; }
            set
            {
                _ammoLeft = value;
                Reloading = AmmoLeft < MagazineCapacity;
            }
        }

        private bool _reloading;
        private bool Reloading
        {
            get { return _reloading; }
            set
            {
                if (!Reloading && value) ReloadTimer = new Counter(50);
                _reloading = value;
            }
        }

        private void ReloadAmmo()
        {
            if (Reloading && ReloadTimer.Update()) AmmoLeft = MagazineCapacity;
        }

        private void CheckCeiling()
        {
            if (SpriteState.Dead) return;
            if ((BarrierCollision.TopLeft | BarrierCollision.TopRight).Cover) MotionState.Fall();
        }

        private void CheckFloor()
        {
            if (SpriteState.Dead) return;
            if (BarrierCollision.Bottom.Touch)
            {
                Land();
                if (!WasOnFloor) Brake();
                WasOnFloor = true;
            }
            else
            {
                Liftoff();
                WasOnFloor = false;
            }
        }

        public void Land()
        {
            if (MotionState.Gravity) MotionState.LoseGravity();
            if (MotionState.DefaultHorizontal) SpriteState.TryStand();
        }

        public void Brake()
        {
            MotionState.Stop();
            SpriteState.Run();
        }

        public void Liftoff()
        {
            MotionState.ObtainGravity();
            MotionState.GetInertia();
            SpriteState.TryJump();
        }

        protected override void UpdateState()
        {
//            if (collision.Bottom.Touch && Core.Object.GoingDown) Core.GeneralMotionState.ResetVertical();
//            if (collision.Top.Touch && Core.Object.GoingUp) Core.GeneralMotionState.ResetVertical();
//            if (collision.Left.Touch && Core.Object.GoingLeft) Core.GeneralMotionState.ResetHorizontal();
//            if (collision.Right.Touch && Core.Object.GoingRight) Core.GeneralMotionState.ResetHorizontal();

            CheckCeiling();
            CheckFloor();
            ReloadAmmo();
        }

        public void GoLeft()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;
            if (MotionState.HaveInertia) return;
            if (MotionState.Stopping && SpriteState.Left && SpriteState.Turning) return;

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
            SpriteState.ToLeft();

            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaLeft();
            else if (MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Left))
                GoLeft();
        }

        public void KeepRight()
        {
            SpriteState.ToRight();
            
            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaRight();
            else if (MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Right))
                GoRight();
        }

        public void StopMove()
        {
            if (SpriteState.Dead) return;
            if (MotionState.HaveInertia) return;
            Brake();
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

        public void StandUp()
        {
            if (SpriteState.Crouching) SpriteState.Stand();
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
            if (AmmoLeft <= 0) return;
            SpriteState.Shoot();
            Core.Object.Generate(
                new Vector2(SpriteState.Left ? -10 : 10, -20),
                SpriteState.Left ? new FireballObject().LeftFireBall : new FireballObject().RightFireBall
                );
            AmmoLeft--;
        }
    }
}