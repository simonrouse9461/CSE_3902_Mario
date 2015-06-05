using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioSpriteState : SpriteStateKernel
    {
        public enum OrientationEnum
        {
            Left,
            Right
        }

        public enum StatusEnum
        {
            Big,
            Small,
            Fire,
            Dead
        }

        public enum ActionEnum
        {
            Jumping,
            Running,
            Facing
        }

        public OrientationEnum Orientation { get; set; }
        public StatusEnum Status { get; set; }
        public ActionEnum Action { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new DeadMovingUpAndDownMarioSprite(),
                new JumpingLeftBMarioSprite(),
                new JumpingLeftFMarioSprite(),
                new JumpingLeftSMarioSprite(),
                new JumpingRightBMarioSprite(),
                new JumpingRightFMarioSprite(),
                new JumpingRightSMarioSprite(),
                new RunningLeftBMarioSprite(),
                new RunningLeftFMarioSprite(),
                new RunningLeftSMarioSprite(),
                new RunningRightBMarioSprite(),
                new RunningRightFMarioSprite(),
                new RunningRightSMarioSprite(),
                new FacingLeftBMarioSprite(),
                new FacingLeftFMarioSprite(),
                new FacingLeftSMarioSprite(),
                new FacingRightBMarioSprite(),
                new FacingRightFMarioSprite(),
                new FacingRightSMarioSprite()
            };
        }

        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Dead)
                return SpriteList[0];
            switch (Action)
            {
                case ActionEnum.Jumping:
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
                case ActionEnum.Running: 
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
                case ActionEnum.Facing:
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
            }
            return SpriteList[0];
        }
    }
}