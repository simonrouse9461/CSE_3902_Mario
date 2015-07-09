﻿using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private const int MagazineCapacity = 2;

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
                if (!Reloading && value) Core.DelayCommand(ReloadAmmo, 50);
                _reloading = value;
            }
        }

        private void ReloadAmmo()
        {
            AmmoLeft = MagazineCapacity;
            Reloading = false;
        }

        public void Land()
        {
            if (SpriteState.Dead) return;
            if (MotionState.Gravity) MotionState.LoseGravity();
            if (MotionState.DefaultHorizontal) SpriteState.TryStand();
        }

        public void Brake()
        {
            if (SpriteState.Dead) return;
            MotionState.Stop();
            SpriteState.Run();
        }

        public void Liftoff()
        {
            if (SpriteState.Dead) return;
            MotionState.ObtainGravity();
            MotionState.GetInertia();
            SpriteState.TryJump();
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

        public void GetStarPower(int slowDownTime, int stopTime)
        {
            SpriteState.StarPower();
            SpriteState.ChangeColorFrequency(8);
            Core.DelayCommand(() => SpriteState.ChangeColorFrequency(16), () => SpriteState.HaveStarPower, slowDownTime);
            Core.DelayCommand(SpriteState.SetDefaultColor, () => SpriteState.HaveStarPower, stopTime);
        }

        public void TakeDamage(int restoreTime)
        {
            SpriteState.BecomeSmall();
            SpriteState.BecomeBlink();
            SpriteState.ChangeColorFrequency(2);
            Core.BarrierHandler.RemoveBarrier<Koopa>();
            Core.BarrierHandler.RemoveBarrier<Goomba>();
            Core.DelayCommand(SpriteState.SetDefaultColor, () => SpriteState.Blinking, restoreTime);
            Core.DelayCommand(() => Core.BarrierHandler.AddBarrier<Koopa>(), restoreTime);
            Core.DelayCommand(() => Core.BarrierHandler.AddBarrier<Goomba>(), restoreTime);
        }
    }
}