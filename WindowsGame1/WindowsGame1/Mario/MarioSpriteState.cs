using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace WindowsGame1
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

        public bool Big { get; private set; }
        public bool Small { get { return !Big; } }

        public MarioSpriteState()
        {
            AddSprite<DeadMarioSprite>();
            AddSprite<JumpingBigMarioSprite>();
            AddSprite<JumpingSmallMarioSprite>();
            AddSprite<RunningBigMarioSprite>();
            AddSprite<RunningSmallMarioSprite>();
            AddSprite<StandingBigMarioSprite>();
            AddSprite<StandingSmallMarioSprite>();
            AddSprite<CrouchingMarioSprite>();
            AddSprite<TurningBigMarioSprite>();
            AddSprite<TurningSmallMarioSprite>();
            AddSprite<GrowingMarioSprite>();
            AddSprite<ShootingMarioSprite>();
            AddSprite<UpgradingMarioSprite>();

            AddColorScheme(ColorScheme.Blink, 
                new[] {Color.White, Color.Transparent});

            AddVersionAnimator(VersionAnimator.StarPower,
                new[]
                {MarioSpriteVersion.Black, MarioSpriteVersion.Default, MarioSpriteVersion.Green, MarioSpriteVersion.Red});
            AddVersionAnimator(VersionAnimator.Upgrade,
                new[]
                {MarioSpriteVersion.Red, MarioSpriteVersion.Black, MarioSpriteVersion.Fire, MarioSpriteVersion.Green});

            SetSpriteFrequency(5);
            SetDefaultVersion(MarioSpriteVersion.Normal);
            Stand();
        }

        public void TurnSmall()
        {
            Big = false;
        }

        public void TurnBig()
        {
            Big = true;
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

        public void LoseFire()
        {
            SetDefaultVersion();
        }

        public bool HaveFire
        {
            get { return IsVersion(MarioSpriteVersion.Fire); }
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

        public bool Grown
        {
            get { return Growing && FindSprite<GrowingMarioSprite>().Cycle >= 1; }
        }

        public void Run()
        {
            if (Big) SetSprite<RunningBigMarioSprite>();
            else SetSprite<RunningSmallMarioSprite>();
        }

        public bool Running
        {
            get
            {
                return IsSprite<RunningBigMarioSprite>() || IsSprite<RunningSmallMarioSprite>();
            }
        }

        public void Jump()
        {
            if (Big) SetSprite<JumpingBigMarioSprite>();
            else SetSprite<JumpingSmallMarioSprite>();
        }

        public bool Jumping
        {
            get { return IsSprite<JumpingBigMarioSprite>() || IsSprite<JumpingSmallMarioSprite>(); }
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
            if (Big) SetSprite<StandingBigMarioSprite>();
            else SetSprite<StandingSmallMarioSprite>();
        }

        public bool Standing
        {
            get { return IsSprite<StandingBigMarioSprite>() || IsSprite<StandingSmallMarioSprite>(); }
        }

        public void Turn()
        {
            if (Big) SetSprite<TurningBigMarioSprite>();
            else SetSprite<TurningSmallMarioSprite>();
        }

        public bool Turning
        {
            get { return IsSprite<TurningBigMarioSprite>() || IsSprite<TurningSmallMarioSprite>(); }
        }

        public void Shoot()
        {
            SetSprite<ShootingMarioSprite>();
        }

        public bool Shooting
        {
            get { return IsSprite<ShootingMarioSprite>(); }
        }
    }
}