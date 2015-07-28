using System;
using Microsoft.Xna.Framework;
using SuperMario.BarrierHandlerDecorators;

namespace SuperMario
{
    public class MarioStateController : StateControllerKernelNew<MarioSpriteState, MarioMotionState>
    {
        private int MagazineCapacity {get { return SpriteState.HaveSuperFire ? 5 : 2; }}

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
                if (!Reloading && value) Core.DelayCommand(ReloadAmmo, SpriteState.HaveSuperFire? 80 : 50);
                _reloading = value;
            }
        }

        private bool HaveExplosive { get; set; }

        public override void Update()
        {
            if (SpriteState.Dead) return;
            if (MotionState.StartFall || MotionState.JumpFinish) 
                MotionState.SlowDownGravity();
            if (MotionState.Going)
            {
                if (MotionState.FullSpeed)
                    SpriteState.SetSpriteFrequency(4);
                else if (MotionState.HalfSpeed)
                    SpriteState.SetSpriteFrequency(5);
                else SpriteState.SetSpriteFrequency(7);
            }
            else SpriteState.SetSpriteFrequency(6);
            if (SpriteState.HaveSuperFire) GenerateShadow();
        }

        private Vector2 LastShadowPosition { get; set; }

        public bool SelfControl { get; private set; }

        public bool OnWarpPipe { get; private set; }

        public void GenerateShadow()
        {
            var displacement = MotionState.Position - LastShadowPosition;
            if (Math.Abs(displacement.X) + Math.Abs(displacement.Y) >= 1)
            {
                Core.Object.Generate(new MarioShadow(SpriteState.Sprite.Clone, SpriteState.Orientation));
                LastShadowPosition = MotionState.Position;
            }
        }

        public void PutExplosive()
        {
            if (SelfControl) return;
            if (HaveExplosive)
            {
                Core.Object.Generate(FireExplosion.BothSide);
                SoundManager.SuperFireSoundPlay();
            }
            HaveExplosive = false;
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
                PutExplosive();
            }
            if (MotionState.Sliping) MotionState.StopSlip();
            DefaultAction();
        }

        public void Liftoff()
        {
            if (SpriteState.Dead) return;
            if (MotionState.Sinking) return;
            if (SpriteState.Sliping) return;

            if (!MotionState.Gravity) MotionState.ObtainGravity();
            if (!MotionState.HaveInertia) MotionState.GetInertia();
            if (SpriteState.HaveSuperFire) HaveExplosive = true;
            DefaultAction();
        }

        public void GoLeft()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;
            if (MotionState.HaveInertia) return;
            if (MotionState.Stopping && SpriteState.IsLeft && SpriteState.Turning) return;

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
            if (MotionState.Stopping && SpriteState.IsRight && SpriteState.Turning) return;
            
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

        public void AssureLeft()
        {
            SpriteState.FaceLeft();

            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;
            if (SpriteState.Sliping) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaLeft();
            else if (MotionState.IsStatic || MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.IsLeft))
            {
                GoLeft();
            }
        }

        public void AssureRight()
        {
            SpriteState.FaceRight();
            
            if (SpriteState.Dead) return;
            if (SpriteState.Crouching) return;
            if (SpriteState.Sliping) return;

            if (MotionState.HaveInertia)
                MotionState.AdjustInertiaRight();
            else if (MotionState.IsStatic || MotionState.DefaultHorizontal || (MotionState.Stopping && SpriteState.IsRight))
            {
                GoRight();
            }
        }

        public void KeepLeft()
        {
            AssureLeft();
            Core.DelayCommand(KeepLeft);
        }

        public void KeepRight()
        {
            AssureRight();
            Core.DelayCommand(KeepRight);
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
            if (SpriteState.IsHeld) return;
            MotionState.Jump();
            SpriteState.Jump();
            if (SpriteState.Small) SoundManager.SmallJumpSoundPlay();
            else SoundManager.SuperJumpSoundPlay();
        }

        public void Bounce()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.HaveSuperFire) return;
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
            if (OnWarpPipe) EnterPipe();
            if (SpriteState.Dead) return;
            if (SpriteState.Small) return;
            if (SpriteState.Jumping) return;
            SpriteState.Crouch();
            SpriteState.Hold(OnWarpPipe);
            MotionState.Stop();
        }

        public void EnterPipe()
        {
            Core.BarrierHandler.RemoveBarrier<IPipe>();
            if (SpriteState.Small) SpriteState.Hold(true);
            MotionState.EnterPipe();
            MotionState.SetDefaultHorizontal();
            MotionState.SetDefaultVertical();
            Core.SwitchComponent(new FinishLevelMarioCommandExecutor(Core));
            SoundManager.PipeSoundPlay();
        }

        public void StandUp()
        {
            if (MotionState.Sinking) return;
            SpriteState.Release();
        }

        public void Die()
        {
            if (SpriteState.Dead) return;
            Core.BarrierHandler.ClearBarrier();
            Core.Object.TurnUnsolid();
            SpriteState.Die();
            MotionState.Die();
            SoundManager.SwitchToFailMusic();
            MotionState.Freeze(40);
        }

        public void Shoot()
        {
            if (!SpriteState.HaveAnyFire) return;
            if (SpriteState.Dead) return;
            if (SpriteState.Upgrading) return;
            if (SpriteState.Shrinking) return;
            if (SpriteState.Sliping) return;
            if (AmmoLeft <= 0) return;
            SpriteState.Shoot();
            SpriteState.Hold(true, 7);
            if (SpriteState.HaveNormalFire)
            {
                Core.Object.Generate(
                new Vector2(SpriteState.IsLeft ? -8 : 8, -24)*GameSettings.SpriteScale,
                SpriteState.IsLeft ? FireballObject.LeftFireBall : FireballObject.RightFireBall
                );
                SoundManager.FireballSoundPlay();
            }
            if (SpriteState.HaveSuperFire) 
            {
                Core.Object.Generate(
                new Vector2(SpriteState.IsLeft ? -16 : 16, -16)*GameSettings.SpriteScale,
                SpriteState.IsLeft ? SuperFireballObject.LeftSuperFireball : SuperFireballObject.RightSuperFireball
                );
                SoundManager.SuperFireSoundPlay();
            }
            AmmoLeft--;
        }

        public void Sprint()
        {
            if (!SpriteState.Super) return;
        }

        public void Flip(float? axis = null)
        {
            if (axis == null) axis = MotionState.Position.X;
            if (SpriteState.IsLeft) SpriteState.FaceRight(); 
            else SpriteState.FaceLeft();
            MotionState.AdjustPosition(new Vector2((axis.Value - MotionState.Position.X) * 2, 0));
        }

        public void Grow()
        {
            if (SpriteState.Dead) return;
            if (!SpriteState.Small) return;
            ReleaseAll();
            SpriteState.Grow();
            WorldManager.FreezeWorld();
            MotionState.Freeze();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () =>
            {
                SpriteState.TurnSuper();
                MotionState.Restore();
                WorldManager.RestoreWorld();
            });
        }

        public void GetFire()
        {
            if (SpriteState.Dead) return;
            if (SpriteState.Upgrading) return;
            if (SpriteState.Small)
            {
                Grow();
                return;
            }
            if (SpriteState.HaveNormalFire || SpriteState.HaveSuperFire)
            {
                GetSuperFire();
                return;
            }
            ReleaseAll();
            SpriteState.Run();
            SpriteState.Upgrade();
            SpriteState.GetFire();
            WorldManager.FreezeWorld();
            MotionState.Freeze();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.VersionAnimation, 3, () =>
            {
                SpriteState.FinishUpgrade();
                MotionState.Restore();
                WorldManager.RestoreWorld();
            });
        }

        public void GetSuperFire()
        {
            SpriteState.GetSuperFire();
        }

        public void GetStarPower()
        {
            const int slowDownTime = 600;
            const int stopTime = 810;
            var decorator = new StarMarioCollisionHandler(Core);
            Core.SwitchComponent(decorator);
            decorator.DelayRestore(stopTime);
            SpriteState.GetPower();
            SoundManager.SwitchToStarPowerMusic();
            Core.DelayCommand(SpriteState.SlowDownPower, () => SpriteState.HavePower, slowDownTime);
            Core.DelayCommand(() =>
            {
                SpriteState.LosePower();
                SoundManager.SwitchToOverworldMusic();
            }, () => SpriteState.HavePower, stopTime);
        }

        public void TakeDamage()
        {
            if (SpriteState.Blinking) return;
            ReleaseAll();
            WorldManager.FreezeWorld();
            if (SpriteState.HaveAnyFire) SpriteState.LoseFire();
            if (SpriteState.Small)
            {
                Die();
                return;
            }

            SpriteState.StartBlink();
            SpriteState.Shrink();
            MotionState.Freeze();
            SoundManager.PowerDownSoundPlay();
            SpriteState.HoldTillFinish(true, () =>
            {
                SpriteState.TurnSmall();
                MotionState.Restore();
                WorldManager.RestoreWorld();
            });
            Core.DelayCommand(SpriteState.StopBlink, () => SpriteState.Blinking, 200);
        }

        public void FinishLevel()
        {
            if (SelfControl) return;
            SelfControl = true;
            ReleaseAll();
            Core.SwitchComponent(new FinishLevelMarioCommandExecutor(Core));
            Core.SwitchComponent(new FinishLevelMarioBarrierHandler(Core));
            Core.BarrierHandler.RemoveBarrier<FlagPoleObject>();
            Core.BarrierHandler.RemoveBarrier<CastleObject>();
            Core.BarrierHandler.RemoveBarrier<FlagObject>();
            MotionState.AdjustPosition(new Vector2(4, 0));
            MotionState.Slip();
            SpriteState.Slip();
            SpriteState.Hold(false);
            SpriteState.FaceRight();
            Camera.Fix();
            SoundManager.StopMusic();
            SoundManager.FlagpoleSoundPlay();
            Core.EventTrigger.AddAbsoluteLocationEvent((int)WorldManager.FindObject<CastleObject>().PositionPoint.X, EnterCastle);
        }

        public void EnterCastle()
        {
            SpriteState.Stand();
            SpriteState.Hold(true);
            MotionState.Freeze();
            SpriteState.Hide();
        }

        public void FoundWarpPipe()
        {
            OnWarpPipe = true;
        }

        public void LeaveWarpPipe()
        {
            OnWarpPipe = false;
        }

        public void ReleaseAll()
        {
            SpriteState.Resume();
            SpriteState.Release();
            MotionState.Restore();
        }
    }
}