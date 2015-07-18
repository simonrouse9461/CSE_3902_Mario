using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioSpriteState : SpriteStateKernelNew
    {
        private enum ActionEnum
        {
            Jump,
            Run,
            Stand,
            Crouch,
            Turn,
            Grow,
            Shoot,
            Die
        }


        private ActionEnum Action { get; set; }
        public bool Big { get; private set; }
        public bool Small { get { return !Big; } }
        public bool Fire { get; private set; }
        public bool Power { get; private set; }
        public bool Blink { get; private set; }

        public MarioSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new DeadMarioSprite(),
                new JumpingBigMarioSprite(),
                new JumpingSmallMarioSprite(),
                new RunningBigMarioSprite(),
                new RunningSmallMarioSprite(),
                new StandingBigMarioSprite(),
                new StandingSmallMarioSprite(),
                new CrouchingMarioSprite(),
                new TurningBigMarioSprite(),
                new TurningSmallMarioSprite(),
                new GrowingMarioSprite(),
                new ShootingMarioSprite()
            };

            ColorSchemeList = new Collection<ColorAnimator>
            {
                new ColorAnimator(new[] {Color.White, Color.Transparent})
            };

            SetSpriteFrequency(5);
        }

        protected override ISpriteNew ActualSprite
        {
            get
            {
                switch (Action)
                {
                    case ActionEnum.Jump:
                        return Big ? FindSprite<JumpingBigMarioSprite>() : FindSprite<JumpingSmallMarioSprite>();
                    case ActionEnum.Run:
                        return Big ? FindSprite<RunningBigMarioSprite>() : FindSprite<RunningSmallMarioSprite>();
                    case ActionEnum.Stand:
                        return Big ? FindSprite<StandingBigMarioSprite>() : FindSprite<StandingSmallMarioSprite>();
                    case ActionEnum.Crouch:
                        return FindSprite<CrouchingMarioSprite>();
                    case ActionEnum.Turn:
                        return Big ? FindSprite<TurningBigMarioSprite>() : FindSprite<TurningSmallMarioSprite>();
                    case ActionEnum.Grow:
                        return FindSprite<GrowingMarioSprite>();
                    case ActionEnum.Shoot:
                        return FindSprite<ShootingMarioSprite>();
                    case ActionEnum.Die:
                        return FindSprite<DeadMarioSprite>();
                    default:
                        return null;
                }
            }
        }

        protected override ColorAnimator ColorScheme
        {
            get { return Blink ? ColorSchemeList[0] : null; }
        }

        public void TurnSmall()
        {
            Big = false;
        }

        public void TurnBig()
        {
            Big = true;
        }

        public void GetFire()
        {
            SetVersion(MarioSpriteVersion.Fire);
            Fire = true;
        }

        public void LoseFire()
        {
            SetVersion(MarioSpriteVersion.Normal);
            Fire = false;
        }

        public void GetPower()
        {
            Power = true;
        }

        public void LosePower()
        {
            Power = false;
        }

        public void StartBlink()
        {
            Blink = true;
        }

        public void StopBlink()
        {
            Blink = false;
        }

        public void Die()
        {
            Action = ActionEnum.Die;
        }

        public bool Dead
        {
            get { return Action == ActionEnum.Die; }
        }

        public void Grow()
        {
            Action = ActionEnum.Grow;
        }

        public bool Growing
        {
            get { return Action == ActionEnum.Grow; }
        }

        public bool Grown
        {
            get { return Growing && FindSprite<GrowingMarioSprite>().Cycle >= 1; }
        }

        public void Run()
        {
            Action = ActionEnum.Run;
        }

        public bool Running
        {
            get { return Action == ActionEnum.Run; }
        }

        public void Jump()
        {
            Action = ActionEnum.Jump;
        }

        public bool Jumping
        {
            get { return Action == ActionEnum.Jump; }
        }

        public void Crouch()
        {
            Action = ActionEnum.Crouch;
        }

        public bool Crouching
        {
            get { return Action == ActionEnum.Crouch; }
        }

        public void Stand()
        {
            Action = ActionEnum.Stand;
        }

        public bool Standing
        {
            get { return Action == ActionEnum.Stand; }
        }

        public void Turn()
        {
            Action = ActionEnum.Turn;
        }

        public bool Turning
        {
            get { return Action == ActionEnum.Turn; }
        }

        public void Shoot()
        {
            Action = ActionEnum.Shoot;
        }

        public bool Shooting
        {
            get { return Action == ActionEnum.Shoot; }
        }
    }
}