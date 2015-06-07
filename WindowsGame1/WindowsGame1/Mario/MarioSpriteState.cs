﻿using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioSpriteState : SpriteStateKernel
    {
        public enum ActionEnum
        {
            Jump,
            Run,
            Stand,
            Crouch
        }

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

        private StatusEnum _status;
        private ActionEnum _action;
        public OrientationEnum Orientation { get; set; }

        public StatusEnum Status
        {
            get { return _status; }
            set
            {
                if (value == StatusEnum.Small && Action == ActionEnum.Crouch)
                {
                    Action = ActionEnum.Stand;
                }
                _status = value;
            }
        }

        public ActionEnum Action
        {
            get { return _action; }
            set
            {
                if (value == ActionEnum.Crouch && Status == StatusEnum.Small)
                {
                    _action = ActionEnum.Stand;
                }
                else
                {
                    _action = value;
                }
            }
        }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new DeadMovingUpAndDownMarioSprite(), //0
                new JumpingLeftBMarioSprite(), //1
                new JumpingLeftFMarioSprite(), //2
                new JumpingLeftSMarioSprite(), //3
                new JumpingRightBMarioSprite(), //4
                new JumpingRightFMarioSprite(), //5
                new JumpingRightSMarioSprite(), //6
                new RunningLeftBMarioSprite(), //7
                new RunningLeftFMarioSprite(), //8
                new RunningLeftSMarioSprite(), //9
                new RunningRightBMarioSprite(), //10
                new RunningRightFMarioSprite(), //11
                new RunningRightSMarioSprite(), //12
                new FacingLeftBMarioSprite(), //13
                new FacingLeftFMarioSprite(), //14
                new FacingLeftSMarioSprite(), //15
                new FacingRightBMarioSprite(), //16
                new FacingRightFMarioSprite(), //17
                new FacingRightSMarioSprite(), //18
                new SitLeftBMarioSprite(), //19
                new SitLeftFMarioSprite(), //20
                new SitRightBMarioSprite(), //21
                new SitRightFMarioSprite() //22
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
            }
            return SpriteList[0];
        }
    }
}