using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioState : IState
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
            Fire
        }

        public enum ActionEnum
        {
            Jumping,
            Running,
            Dead
        }

        public OrientationEnum Orientation { get; set; }
        public StatusEnum Status { get; set; }
        public ActionEnum Action { get; set; }

        public MarioState()
        {
            
        }

        public ISprite ActiveSprite()
        {
            switch (Action)
            {
                case 'd':
                    return MarioSpriteEnum.Dead;
                case 'j':
                    switch (Status)
                    {
                        case 'b':
                            return Orientation ? MarioSpriteEnum.JumpingLeftB : MarioSpriteEnum.JumpingRightB;
                        case 'f':
                            return Orientation ? MarioSpriteEnum.JumpingLeftF : MarioSpriteEnum.JumpingRightF;
                        case 's':
                            return Orientation ? MarioSpriteEnum.JumpingLeftS : MarioSpriteEnum.JumpingRightS;
                    }
                    break;
                case 'r': switch (Status)
                    {
                        case 'b':
                            return Orientation ? MarioSpriteEnum.RunningLeftB : MarioSpriteEnum.RunningRightB;
                        case 'f':
                            return Orientation ? MarioSpriteEnum.RunningLeftF : MarioSpriteEnum.RunningRightF;
                        case 's':
                            return Orientation ? MarioSpriteEnum.RunningLeftS : MarioSpriteEnum.RunningRightS;
                    }
                    break;
                    
            }
            return MarioSpriteEnum.Dead;
        }

        public Vector2 NetMotion()
        {
            return default(Vector2);
        }
    }
}