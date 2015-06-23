using System.Collections.ObjectModel;
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
            Swim
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

        private StatusEnum Status;
        private ActionEnum Action;
        private OrientationEnum Orientation;
        private bool StarPower;

        public MarioSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
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
                new SwimmingSmallMarioSprite()
            };

            ColorSchemeList = new Collection<ColorAnimator>
            {
                new ColorAnimator(new[] {Color.Red, Color.Yellow, Color.Green, Color.Blue}, 8)
            };

            ChangeFrequency(5);
        }

        public override ISpriteNew Sprite
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
                }
                return SpriteList[0];
            }
        }

        public override Color Color
        {
            get
            {
                return StarPower ? ColorSchemeList[0].Color : Color.White;
            }
        }

        public void ToLeft()
        {
            Orientation = OrientationEnum.Left;
        }

        public override bool Left
        {
            get { return Orientation == OrientationEnum.Left; }
        }

        public void ToRight()
        {
            Orientation = OrientationEnum.Right;
        }

        public override bool Right
        {
            get { return Orientation == OrientationEnum.Right; }
        }

        public void ToDefault()
        {
            Orientation = OrientationEnum.Default;
        }

        public void BecomeBig()
        {
            Status = StatusEnum.Big;
        }

        public bool Big
        {
            get { return Status == StatusEnum.Big; }
        }

        public void BecomeSmall()
        {
            Status = StatusEnum.Small;
            if (Action == ActionEnum.Crouch)
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

        public void GetFire()
        {
            Status = StatusEnum.Fire;
        }

        public bool HaveFire
        {
            get { return Status == StatusEnum.Fire; }
        }

        public void GetStarPower()
        {
            StarPower = true;
        }

        public void LoseStarPower()
        {
            StarPower = false;
        }

        public bool HaveStarPower
        {
            get { return StarPower; }
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
            Action = Status == StatusEnum.Small ? ActionEnum.Stand : ActionEnum.Crouch;
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
        public void Swim()
        {
            Action = ActionEnum.Swim;
        }

        public bool Swimming
        {
            get { return Action == ActionEnum.Swim; }
        }
    }
}