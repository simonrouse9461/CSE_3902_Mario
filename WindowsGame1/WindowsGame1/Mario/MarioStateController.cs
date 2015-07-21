﻿using System;
using MarioGame.CommandExecutorDecorators;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioStateController : StateControllerKernelNew<MarioSpriteState, MarioMotionState>
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

        public void ReloadAmmo()
        {
            AmmoLeft = MagazineCapacity;
            Reloading = false;
        }

        public void DefaultAction()
        {
            if (MotionState.DefaultHorizontal) SpriteState.Stand();
            if (MotionState.GoingLeft || MotionState.GoingRight) SpriteState.Run();
            if (MotionState.HaveInertia) SpriteState.Jump();
        }

        public void KeepOnLand()
        {
            if (SpriteState.Dead) return;
            if (MotionState.Gravity) MotionState.LoseGravity();
            if (MotionState.HaveInertia)
            {
                MotionState.Stop();
                SpriteState.Run();
            }
            DefaultAction();
        }

        public void Liftoff()
        {
            if (SpriteState.Dead) return;
            if (!MotionState.Gravity) MotionState.ObtainGravity();
            if (!MotionState.HaveInertia) MotionState.GetInertia();
            DefaultAction();
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
            SpriteState.FaceLeft();

            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaLeft();
            else if (MotionState.Static || MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Left))
                GoLeft();
        }

        public void KeepRight()
        {
            SpriteState.FaceRight();
            
            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaRight();
            else if (MotionState.Static || MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Right))
                GoRight();
        }

        public void StopMove()
        {
            if (SpriteState.Dead) return;
            if (MotionState.HaveInertia) return;
            MotionState.Stop();
            SpriteState.Run();
        }

        public void Jump()
        {
            if (SpriteState.Dead) return;
            if (MotionState.HaveInertia) return;
            if (SpriteState.Held) return;
            MotionState.Jump();
            SpriteState.Jump();
            if (SpriteState.Small) SoundManager.SmallJumpSoundPlay();
            else SoundManager.SuperJumpSoundPlay();
        }

        public void Bounce()
        {
            if (SpriteState.Dead) return;
            MotionState.Bounce();
            SpriteState.Jump();
        }

        public void Fall()
        {
            if (SpriteState.Dead) return;
            MotionState.Fall();
        }

        public void Crouch()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.Small) return;
            SpriteState.Crouch();
            SpriteState.Hold(false);
            MotionState.Stop();
        }

        public void StandUp()
        {
            SpriteState.Release();
        }

        public void Die()
        {
            if (SpriteState.Dead) return;
            SpriteState.Die();
            MotionState.Die();
            SoundManager.ChangeToDieMusic();
            MotionState.Freeze(40);
        }

        public void Shoot()
        {
            if (SpriteState.Dead) return;
            if (AmmoLeft <= 0) return;
            SpriteState.Shoot();
            SpriteState.Hold(true, 7);
            Core.Object.Generate(
                new Vector2(SpriteState.Left ? -10 : 10, -25),
                SpriteState.Left ? FireballObject.LeftFireBall : FireballObject.RightFireBall
                );
            AmmoLeft--;
            SoundManager.FireballSoundPlay();
        }

        public void Grow()
        {
            if (SpriteState.Dead) return;
            if (!SpriteState.Small) return;
            SpriteState.Grow();
            WorldManager.FreezeWorld();
            MotionState.Freeze();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () =>
            {
                SpriteState.TurnBig();
                MotionState.Restore();
                WorldManager.RestoreWorld();
            });
        }

        public void GetFire()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.HaveFire) return;
            if (SpriteState.Upgrading) return;
            SpriteState.Run();
            SpriteState.Upgrade();
            SpriteState.GetFire();
            WorldManager.FreezeWorld();
            MotionState.Freeze();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.VersionAnimation, 4, () =>
            {
                SpriteState.FinishUpgrade();
                MotionState.Restore();
                WorldManager.RestoreWorld();
            });
            Core.SwitchComponent(new FireMarioCommandExecutor(Core));
        }

        public void GetStarPower()
        {
            const int slowDownTime = 600;
            const int stopTime = 810;
            var decorator = new StarMarioCollisionHandler(Core);
            Core.SwitchComponent(decorator);
            decorator.DelayRestore(stopTime);
            SpriteState.GetPower();
            SoundManager.ChangeToStarMusic();
            Core.DelayCommand(SpriteState.SlowDownPower, () => SpriteState.HavePower, slowDownTime);
            Core.DelayCommand(() =>
            {
                SpriteState.LosePower();
                SoundManager.ChangeToOverworldMusic();
            }, () => SpriteState.HavePower, stopTime);
        }

        public void TakeDamage()
        {
            const int restoreTime = 200;
            WorldManager.FreezeWorld();
            if (SpriteState.Small)
            {
                Die();
                return;
            }

            if (SpriteState.HaveFire)
            {
                ((IDecorator) Core.CommandExecutor).Restore();
                SpriteState.LoseFire();
            }

            var decorator = new DamagedMarioCollisionHandler(Core);
            Core.SwitchComponent(decorator);
            decorator.DelayRestore(restoreTime);

            SpriteState.StartBlink();
            SpriteState.Shrink();
            MotionState.Freeze();
            SoundManager.PowerDownSoundPlay();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () =>
            {
                SpriteState.TurnSmall();
                MotionState.Restore();
                WorldManager.RestoreWorld();
            });
            Core.BarrierHandler.RemoveBarrier<Koopa>();
            Core.BarrierHandler.RemoveBarrier<Goomba>();

            Core.DelayCommand(SpriteState.StopBlink, () => SpriteState.Blinking, restoreTime);
            Core.DelayCommand(() => Core.BarrierHandler.AddBarrier<Koopa>(), restoreTime);
            Core.DelayCommand(() => Core.BarrierHandler.AddBarrier<Goomba>(), restoreTime);
        }
    }
}