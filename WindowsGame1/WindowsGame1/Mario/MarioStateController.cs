using System;
using WindowsGame1.CommandExecutorDecorators;
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

        public override void Update()
        {
            if (SpriteState.FinishGrow)
            {
                DefaultAction();
                MotionState.Restore();
                ((IDecorator)Core.CommandExecutor).Restore();
                WorldManager.RestoreWorld();
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
            //if (MotionState.Stopping)
            // TODO
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
            SpriteState.TryRun();
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
                SpriteState.TryRun();
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
                SpriteState.TryRun();
            }
        }

        public void KeepLeft()
        {
            SpriteState.ToLeft();

            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaLeft();
            else if (MotionState.Static || MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.Left))
                GoLeft();
        }

        public void KeepRight()
        {
            SpriteState.ToRight();
            
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
            Brake();
        }

        public void Jump()
        {
            if (SpriteState.Dead) return;
            if (MotionState.HaveInertia) return;
            MotionState.Jump();
            SpriteState.Jump();
            SoundManager.JumpSoundPlay();
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
            SpriteState.TryCrouch();
            MotionState.Stop();
        }

        public void StandUp()
        {
            if (SpriteState.Crouching) SpriteState.Stand();
        }

        public void Grow()
        {
            if (SpriteState.Dead) return;
            if (!SpriteState.Small) return;
            SpriteState.GrowBig();
            MotionState.Freeze();
            Core.SwitchComponent(new TransformingMarioCommandExecutor(Core));
            WorldManager.FreezeWorld();
            SoundManager.powerUpSoundPlay();
        }
        
        public void GetFire()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.HaveFire) return;
            SpriteState.GetFire();
            Core.SwitchComponent(new FireMarioCommandExecutor(Core));
            SoundManager.powerUpSoundPlay();
        }

        public void Die()
        {
            if (SpriteState.Dead) return;
            SpriteState.BecomeDead();
            MotionState.Die();
            WorldManager.FreezeWorld();
        }

        public void Shoot()
        {
            if (SpriteState.Dead) return;
            if (AmmoLeft <= 0) return;
            SpriteState.Shoot();
            Core.DelayCommand(DefaultAction, () => SpriteState.Shooting, 7);
            Core.Object.Generate(
                new Vector2(SpriteState.Left ? -10 : 10, -20),
                SpriteState.Left ? FireballObject.LeftFireBall : FireballObject.RightFireBall
                );
            AmmoLeft--;
        }

        public void GetStarPower(int slowDownTime, int stopTime)
        {
            var decorator = new StarMarioCollisionHandler(Core);
            Core.SwitchComponent(decorator);
            decorator.DelayRestore(stopTime);

            SpriteState.StarPower();
            SpriteState.ChangeColorFrequency(8);
            Core.DelayCommand(() => SpriteState.ChangeColorFrequency(16), () => SpriteState.HaveStarPower, slowDownTime);
            Core.DelayCommand(SpriteState.SetDefaultColor, () => SpriteState.HaveStarPower, stopTime);
        }

        public void TakeDamage(int restoreTime)
        {
            if (SpriteState.Small)
            {
                Die();
                return;
            }

            if (SpriteState.HaveFire) ((IDecorator)Core.CommandExecutor).Restore();

            var decorator = new DamagedMarioCollisionHandler(Core);
            Core.SwitchComponent(decorator);
            decorator.DelayRestore(restoreTime);

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