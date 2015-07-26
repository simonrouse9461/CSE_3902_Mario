using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MarioSpriteState : SpriteStateKernelNew<MarioSpriteVersion>
    {
        private enum ColorScheme
        {
            Blink
        }

        private enum VersionAnimator
        {
            StarPower,
            Upgrade
        }

        public bool Super { get; private set; }
        public bool Small { get { return !Super; } }

        public MarioSpriteState()
        {
            AddSprite<DeadMarioSprite>();
            AddSprite<JumpingSuperMarioSprite>();
            AddSprite<JumpingSmallMarioSprite>();
            AddSprite<RunningSuperMarioSprite>();
            AddSprite<RunningSmallMarioSprite>();
            AddSprite<StandingSuperMarioSprite>();
            AddSprite<StandingSmallMarioSprite>();
            AddSprite<CrouchingMarioSprite>();
            AddSprite<TurningSuperMarioSprite>();
            AddSprite<TurningSmallMarioSprite>();
            AddSprite<GrowingMarioSprite>();
            AddSprite<ShrinkingMarioSprite>();
            AddSprite<ShootingMarioSprite>();
            AddSprite<UpgradingMarioSprite>();
            AddSprite<SlipingSmallMarioSprite>();
            AddSprite<SlipingSuperMarioSprite>();

            AddColorScheme(ColorScheme.Blink, 
                new[] {Color.White, Color.Transparent});

            AddVersionAnimator(VersionAnimator.StarPower,
                new[]
                {MarioSpriteVersion.Black, MarioSpriteVersion.Default, MarioSpriteVersion.Green, MarioSpriteVersion.Red});
            AddVersionAnimator(VersionAnimator.Upgrade,
                new[]
                {MarioSpriteVersion.Red, MarioSpriteVersion.Black, MarioSpriteVersion.Fire, MarioSpriteVersion.Green});

            SetSpriteFrequency(4);
            SetDefaultVersion(MarioSpriteVersion.Normal);
            Stand();
        }

        public void TurnSmall()
        {
            Super = false;
        }

        public void TurnSuper()
        {
            Super = true;
        }

        public void Upgrade()
        {
            SetSprite<UpgradingMarioSprite>();
            SetVersionAnimator(VersionAnimator.Upgrade);
            SetVersionFrequency(5);
        }

        public bool Upgrading
        {
            get { return IsSprite<UpgradingMarioSprite>(); }
        }

        public void FinishUpgrade()
        {
            StopVersionAnimator(VersionAnimator.Upgrade);
        }

        public void GetFire()
        {
            SetVersion(MarioSpriteVersion.Fire);
        }

        public void GetSuperFire()
        {
            SetVersion(MarioSpriteVersion.Black);
        }

        public void LoseFire()
        {
            SetDefaultVersion();
        }

        public bool HaveFire
        {
            get { return IsVersion(MarioSpriteVersion.Fire); }
        }

        public bool HaveSuperFire
        {
            get { return IsVersion(MarioSpriteVersion.Black); }
        }

        public void GetPower()
        {
            SetVersionAnimator(VersionAnimator.StarPower);
            SetVersionFrequency(2);
        }

        public void SlowDownPower()
        {
            SetVersionFrequency(10);
        }

        public bool HavePower
        {
            get { return IsVersionAnimator(VersionAnimator.StarPower); }
        }

        public void LosePower()
        {
            StopVersionAnimator(VersionAnimator.StarPower);
        }

        public void StartBlink()
        {
            SetColorScheme(ColorScheme.Blink);
            SetColorFrequency(3);
        }

        public void StopBlink()
        {
            RestoreColorScheme();
        }

        public bool Blinking
        {
            get { return IsColorScheme(ColorScheme.Blink); }
        }

        public void Die()
        {
            SetSprite<DeadMarioSprite>();
        }

        public bool Dead
        {
            get { return IsSprite<DeadMarioSprite>(); }
        }

        public void Grow()
        {
            SetSprite<GrowingMarioSprite>();
        }

        public bool Growing
        {
            get { return IsSprite<GrowingMarioSprite>(); }
        }

        public void Shrink()
        {
            SetSprite<ShrinkingMarioSprite>();
        }

        public bool Shrinking()
        {
            return IsSprite<ShrinkingMarioSprite>();
        }

        public void Run()
        {
            if (Super) SetSprite<RunningSuperMarioSprite>();
            else SetSprite<RunningSmallMarioSprite>();
        }

        public bool Running
        {
            get
            {
                return IsSprite<RunningSuperMarioSprite>() || IsSprite<RunningSmallMarioSprite>();
            }
        }

        public void Jump()
        {
            if (Super) SetSprite<JumpingSuperMarioSprite>();
            else SetSprite<JumpingSmallMarioSprite>();
        }

        public bool Jumping
        {
            get { return IsSprite<JumpingSuperMarioSprite>() || IsSprite<JumpingSmallMarioSprite>(); }
        }

        public void Crouch()
        {
            SetSprite<CrouchingMarioSprite>();
        }

        public bool Crouching
        {
            get { return IsSprite<CrouchingMarioSprite>(); }
        }

        public void Stand()
        {
            if (Super) SetSprite<StandingSuperMarioSprite>();
            else SetSprite<StandingSmallMarioSprite>();
        }

        public bool Standing
        {
            get { return IsSprite<StandingSuperMarioSprite>() || IsSprite<StandingSmallMarioSprite>(); }
        }

        public void Turn()
        {
            if (Super) SetSprite<TurningSuperMarioSprite>();
            else SetSprite<TurningSmallMarioSprite>();
        }

        public bool Turning
        {
            get { return IsSprite<TurningSuperMarioSprite>() || IsSprite<TurningSmallMarioSprite>(); }
        }

        public void Shoot()
        {
            SetSprite<ShootingMarioSprite>();
        }

        public bool Shooting
        {
            get { return IsSprite<ShootingMarioSprite>(); }
        }

        public void Slip()
        {
            if (Super) SetSprite<SlipingSuperMarioSprite>();
            else SetSprite<SlipingSmallMarioSprite>();
        }

        public bool Sliping
        {
            get { return IsSprite<SlipingSmallMarioSprite>() || IsSprite<SlipingSuperMarioSprite>(); }
        }
    }
}