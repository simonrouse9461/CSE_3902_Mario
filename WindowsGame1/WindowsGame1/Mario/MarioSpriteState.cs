using System;
using System.Collections.Generic;

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
            Break
        }

        private enum OrientationEnum
        {
            Left,
            Right
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

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new DeadMarioSprite(), //0
                new JumpingLeftBigMarioSprite(), //1
                new JumpingLeftFireMarioSprite(), //2
                new JumpingLeftSmallMarioSprite(), //3
                new JumpingRightBigMarioSprite(), //4
                new JumpingRightFireMarioSprite(), //5
                new JumpingRightSmallMarioSprite(), //6
                new RunningLeftBigMarioSprite(), //7
                new RunningLeftFireMarioSprite(), //8
                new RunningLeftSmallMarioSprite(), //9
                new RunningRightBigMarioSprite(), //10
                new RunningRightFireMarioSprite(), //11
                new RunningRightSmallMarioSprite(), //12
                new FacingLeftBigMarioSprite(), //13
                new FacingLeftFireMarioSprite(), //14
                new FacingLeftSmallMarioSprite(), //15
                new FacingRightBigMarioSprite(), //16
                new FacingRightFireMarioSprite(), //17
                new FacingRightSmallMarioSprite(), //18
                new CrouchingLeftBigMarioSprite(), //19
                new CrouchingLeftFireMarioSprite(), //20
                new CrouchingRightBigMarioSprite(), //21
                new CrouchingRightFireMarioSprite(), //22
                new BreakingLeftBigMarioSprite(), //23
                new BreakingRightBigMarioSprite() //24
            };
        }

        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Dead)
                return SpriteList[0];
            switch (Action)
            {
                case ActionEnum.Jump:
                    switch (Status)
                    {
                        case StatusEnum.Big:
                            return Orientation == OrientationEnum.Left ? SpriteList[1] : SpriteList[4];
                        case StatusEnum.Fire:
                            return Orientation == OrientationEnum.Left ? SpriteList[2] : SpriteList[5];
                        case StatusEnum.Small:
                            return Orientation == OrientationEnum.Left ? SpriteList[3] : SpriteList[6];
                    }
                    break;
                case ActionEnum.Run:
                    switch (Status)
                    {
                        case StatusEnum.Big:
                            return Orientation == OrientationEnum.Left ? SpriteList[7] : SpriteList[10];
                        case StatusEnum.Fire:
                            return Orientation == OrientationEnum.Left ? SpriteList[8] : SpriteList[11];
                        case StatusEnum.Small:
                            return Orientation == OrientationEnum.Left ? SpriteList[9] : SpriteList[12];
                    }
                    break;
                case ActionEnum.Stand:
                    switch (Status)
                    {
                        case StatusEnum.Big:
                            return Orientation == OrientationEnum.Left ? SpriteList[13] : SpriteList[16];
                        case StatusEnum.Fire:
                            return Orientation == OrientationEnum.Left ? SpriteList[14] : SpriteList[17];
                        case StatusEnum.Small:
                            return Orientation == OrientationEnum.Left ? SpriteList[15] : SpriteList[18];
                    }
                    break;
                case ActionEnum.Crouch:
                    switch (Status)
                    {
                        case StatusEnum.Big:
                            return Orientation == OrientationEnum.Left ? SpriteList[19] : SpriteList[21];
                        case StatusEnum.Fire:
                            return Orientation == OrientationEnum.Left ? SpriteList[20] : SpriteList[22];
                    }
                    break;
                case ActionEnum.Break:
                    switch (Status)
                    {
                        case StatusEnum.Big:
                            return Orientation == OrientationEnum.Left ? SpriteList[23] : SpriteList[24];
                        case StatusEnum.Fire:
                            return Orientation == OrientationEnum.Left ? SpriteList[23] : SpriteList[24];
                        case StatusEnum.Small:
                            return Orientation == OrientationEnum.Left ? SpriteList[23] : SpriteList[24];
                    }
                    break;
            }
            return SpriteList[0];
        }

        public void FaceLeft()
        {
            Orientation = OrientationEnum.Left;
        }

        public bool IsLeft()
        {
            return Orientation == OrientationEnum.Left;
        }

        public void FaceRight()
        {
            Orientation = OrientationEnum.Right;
        }

        public bool IsRight()
        {
            return Orientation == OrientationEnum.Right;
        }

        public void BecomeBig()
        {
            Status = StatusEnum.Big;
        }

        public bool IsBig()
        {
            return Status == StatusEnum.Big;
        }

        public void BecomeSmall()
        {
            Status = StatusEnum.Small;
            if (Action == ActionEnum.Crouch)
            {
                Action = ActionEnum.Stand;
            }
        }

        public bool IsSmall()
        {
            return Status == StatusEnum.Small;
        }

        public void BecomeDead()
        {
            Status = StatusEnum.Dead;
        }

        public bool IsDead()
        {
            return Status == StatusEnum.Dead;
        }

        public void BecomeFire()
        {
            Status = StatusEnum.Fire;
        }

        public bool IsFire()
        {
            return Status == StatusEnum.Fire;
        }

        public void Run()
        {
            Action = ActionEnum.Run;
        }

        public bool IsRun()
        {
            return Action == ActionEnum.Run;
        }

        public void Jump()
        {
            Action = ActionEnum.Jump;
        }

        public bool IsJump()
        {
            return Action == ActionEnum.Jump;
        }

        public void Crouch()
        {
            Action = Status == StatusEnum.Small ? ActionEnum.Stand : ActionEnum.Crouch;
        }

        public bool IsCrouch()
        {
            return Action == ActionEnum.Crouch;
        }

        public void Stand()
        {
            Action = ActionEnum.Stand;
        }

        public bool IsStand()
        {
            return Action == ActionEnum.Stand;
        }

        public void Break()
        {
            Action = ActionEnum.Break;
        }

        public bool IsBreak()
        {
            return Action == ActionEnum.Break;
        }
    }
}