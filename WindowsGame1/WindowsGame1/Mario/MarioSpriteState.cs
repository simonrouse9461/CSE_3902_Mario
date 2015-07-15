using System.Collections.ObjectModel;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioSpriteState : SpriteStateKernel
    {
        private enum ActionEnum
        {
            Jump,
            Run,
            Stand,
            Crouch,
            Turn,
            Swim,
            Grow,
            Back,
            Shoot
        }

        private enum OrientationEnum
        {
            Left,
            Right,
            Default
        }

        private enum StatusEnum
        {
            Big,
            Small,
            Fire,
            Dead
        }

        private enum ColorEnum
        {
            None,
            StarPower,
            Blink
        }

        private StatusEnum Status;
        private ActionEnum Action;
        private OrientationEnum Orientation;
        private ColorEnum ColorMode;

        public MarioSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new DeadMarioSprite(),
                new JumpingBigMarioSprite(),
                new JumpingFireMarioSprite(),
                new JumpingSmallMarioSprite(),
                new RunningBigMarioSprite(),
                new RunningFireMarioSprite(),
                new RunningSmallMarioSprite(),
                new StandingBigMarioSprite(),
                new StandingFireMarioSprite(),
                new StandingSmallMarioSprite(),
                new CrouchingBigMarioSprite(),
                new CrouchingFireMarioSprite(),
                new TurningBigMarioSprite(),
                new TurningFireMarioSprite(),
                new TurningSmallMarioSprite(),
                new SwimmingBigMarioSprite(),
                new SwimmingFireMarioSprite(),
                new SwimmingSmallMarioSprite(),
                new GrowingBigMarioSprite(),
                new GrowingFireMarioSprite(),
                new DeGrowingBigMarioSprite(),
                new DeGrowingFireMarioSprite(),
                new ShootingMarioSprite()
            };

            ColorSchemeList = new Collection<ColorAnimator>
            {
                new ColorAnimator(new[] {Color.Red, Color.Yellow, Color.Green, Color.Blue}),
                new ColorAnimator(new[] {Color.White, Color.Transparent})
            };

            ChangeSpriteFrequency(5);
        }

        protected override ISprite RawSprite
        {
            get
            {
                if (Status == StatusEnum.Dead)
                    return FindSprite<DeadMarioSprite>();
                switch (Action)
                {
                    case ActionEnum.Jump:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<JumpingBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<JumpingFireMarioSprite>();
                            case StatusEnum.Small:
                                return FindSprite<JumpingSmallMarioSprite>();
                        }
                        break;
                    case ActionEnum.Run:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<RunningBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<RunningFireMarioSprite>();
                            case StatusEnum.Small:
                                return FindSprite<RunningSmallMarioSprite>();
                        }
                        break;
                    case ActionEnum.Stand:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<StandingBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<StandingFireMarioSprite>();
                            case StatusEnum.Small:
                                return FindSprite<StandingSmallMarioSprite>();
                        }
                        break;
                    case ActionEnum.Crouch:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<CrouchingBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<CrouchingFireMarioSprite>();
                        }
                        break;
                    case ActionEnum.Turn:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<TurningBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<TurningFireMarioSprite>();
                            case StatusEnum.Small:
                                return FindSprite<TurningSmallMarioSprite>();
                        }
                        break;
                    case ActionEnum.Swim:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<SwimmingBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<SwimmingFireMarioSprite>();
                            case StatusEnum.Small:
                                return FindSprite<SwimmingSmallMarioSprite>();
                        }
                        break;
                    case ActionEnum.Grow:
                        switch (Status)
                        {
                            case StatusEnum.Big:
                                return FindSprite<GrowingBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<GrowingFireMarioSprite>();
                        }
                        break;
                    case ActionEnum.Back:
                        switch (Status)
                        {
                            case StatusEnum.Small:
                                return FindSprite<StandingSmallMarioSprite>();
                            case StatusEnum.Big:
                                return FindSprite<DeGrowingBigMarioSprite>();
                            case StatusEnum.Fire:
                                return FindSprite<DeGrowingFireMarioSprite>();
                        }
                        break;
                    case ActionEnum.Shoot:
                        switch (Status)
                        {
                            case StatusEnum.Fire:
                                return FindSprite<ShootingMarioSprite>();
                        }
                        break;
                }
                return null;
            }
        }

        protected override ColorAnimator ColorScheme 
        {
            get
            {
                switch (ColorMode)
                {
                    case ColorEnum.StarPower:
                        return ColorSchemeList[0];
                    case ColorEnum.Blink:
                        return ColorSchemeList[1];
                    default:
                        return null;
                }
            }
        }

        public override bool Left
        {
            get { return Orientation == OrientationEnum.Left; }
        }

        public override bool Right
        {
            get { return Orientation == OrientationEnum.Right; }
        }

        public void ToLeft()
        {
            Orientation = OrientationEnum.Left;
        }

        public void ToRight()
        {
            Orientation = OrientationEnum.Right;
        }

        public void ToDefault()
        {
            Orientation = OrientationEnum.Default;
        }

        public void BecomeSmall()
        {
            Status = StatusEnum.Small;
            if (Crouching)
            {
                Action = ActionEnum.Stand;
            }
        }

        public bool Small
        {
            get { return Status == StatusEnum.Small; }
        }

        public void BecomeDead()
        {
            Status = StatusEnum.Dead;
        }

        public bool Dead
        {
            get { return Status == StatusEnum.Dead; }
        }

        public void GrowBig()
        {
            Status = StatusEnum.Big;
            Action = ActionEnum.Grow;
        }

        public bool Big
        {
            get { return Status == StatusEnum.Big; }
        }

        public void GetFire()
        {
            Status = StatusEnum.Fire;
            Action = ActionEnum.Grow;
        }

        public bool HaveFire
        {
            get { return Status == StatusEnum.Fire; }
        }

        public bool Growing
        {
            get { return Action == ActionEnum.Grow; }
        }

        public bool FinishGrow
        {
            get
            {
                return Big && FindSprite<GrowingBigMarioSprite>().Cycle == 1 ||
                       HaveFire && FindSprite<GrowingFireMarioSprite>().Cycle == 1;
            }
        }

        public void StarPower()
        {
            ColorMode = ColorEnum.StarPower;
        }

        public bool HaveStarPower
        {
            get { return ColorMode == ColorEnum.StarPower; }
        }

        public void BecomeBlink()
        {
            ColorMode = ColorEnum.Blink;
        }

        public bool Blinking
        {
            get { return ColorMode == ColorEnum.Blink; }
        }

        public void SetDefaultColor()
        {
            ColorMode = ColorEnum.None;
        }

        public void Run()
        {
            Action = ActionEnum.Run;
        }

        public void TryRun()
        {
            if (Shooting || Growing) return;
            Run();
        }

        public bool Running
        {
            get { return Action == ActionEnum.Run; }
        }

        public void Jump()
        {
            Action = ActionEnum.Jump;
        }

        public void TryJump()
        {
            if (Shooting || Growing) return;
            Jump();
        }

        public bool Jumping
        {
            get { return Action == ActionEnum.Jump; }
        }

        public void Crouch()
        {
            Action = ActionEnum.Crouch;
        }

        public void TryCrouch()
        {
            if (Shooting || Growing || Small) return;
            Crouch();
        }

        public bool Crouching
        {
            get { return Action == ActionEnum.Crouch; }
        }

        public void Stand()
        {
            Action = ActionEnum.Stand;
        }

        public void TryStand()
        {
            if (Shooting || Crouching || Growing) return;
            Stand();
        }

        public bool Standing
        {
            get { return Action == ActionEnum.Stand; }
        }

        public void Turn()
        {
            if (Shooting || Growing) return;
            Action = ActionEnum.Turn;
        }

        public bool Turning
        {
            get { return Action == ActionEnum.Turn; }
        }
        public void Swim()
        {
            if (Shooting) return;
            Action = ActionEnum.Swim;
        }

        public bool Swimming
        {
            get { return Action == ActionEnum.Swim; }
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