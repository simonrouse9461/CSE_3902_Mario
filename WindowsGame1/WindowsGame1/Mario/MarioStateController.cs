using System;

namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private Collision collision;
        private bool dead;
        private bool alreadyShot;
        private bool moving;
        private bool jumping;

        private void CheckMovement()
        {
            if (!moving && !MotionState.InMidAir)
            {
                if (MotionState.DefaultHorizontal)
                    SpriteState.Stand();
                else MotionState.Stop();
            }
        }

        private void CheckJump()
        {
            if (!jumping)
            {
                MotionState.Fall();
            }
        }

        private void CheckWall()
        {
            if (collision.AnySide.Touch && MotionState.InMidAir)
                MotionState.MidAirStop();
        }

        private void CheckCeiling()
        {
            if ((collision.TopLeft & collision.TopRight).Touch)
            {
                MotionState.Fall();
            }
        }

        private void CheckFloor()
        {
            if (collision.Bottom.Touch)
            {
                MotionState.LoseGravity();
                if (MotionState.InMidAir)
                {
                    if (MotionState.Velocity.X > 0) MotionState.GoRight();
                    else MotionState.GoLeft();
                    SpriteState.Run();
                }
            }
            else
            {
                MotionState.ObtainGravity();
                SpriteState.Jump();
            }
        }

        private void CheckShoot()
        {
            if (SpriteState.Shooting && !alreadyShot)
                Core.DelayCommand(() => alreadyShot = true, 8);
            if (!SpriteState.Shooting && alreadyShot)
                alreadyShot = false;
        }

        private void CheckDead()
        {
            if (dead)
            {
                SpriteState.BecomeDead();
                MotionState.Die();
            }
        }

        private void RestoreStatus()
        {
            moving = false;
            jumping = false;
        }

        protected override void UpdateState()
        {
            collision = Core.CollisionDetector.Detect<IObject>(obj => obj.Solid);
            CheckMovement();
            CheckJump();
            CheckWall();
            CheckCeiling();
            CheckFloor();
            CheckShoot();
            CheckDead();
            RestoreStatus();
        }

        public void GoLeft()
        {
            moving = true;
            SpriteState.ToLeft();
            if (MotionState.DefaultHorizontal)
            {
                MotionState.GoLeft();
                SpriteState.Run();
            }
            else if (MotionState.InMidAir)
            {
                MotionState.MidAirLeft();
            }
            else if (!MotionState.GoingLeft)
            {
                MotionState.Stop();
                SpriteState.Turn();
            }
            else SpriteState.Run();
        }

        public void GoRight()
        {
            moving = true;
            SpriteState.ToRight();
            if (MotionState.DefaultHorizontal)
            {
                MotionState.GoRight();
                SpriteState.Run();
            }
            else if (MotionState.InMidAir)
            {
                MotionState.MidAirRight();
            }
            else if (!MotionState.GoingRight)
            {
                MotionState.Stop();
                SpriteState.Turn();
            }
            else SpriteState.Run();
        }

        public void Jump()
        {
            jumping = true;
            if (!MotionState.InMidAir)
            {
                MotionState.GoMidAir();
                MotionState.Jump();
                SpriteState.Jump();
            }
        }

        public void Crouch()
        {
            SpriteState.Crouch();
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