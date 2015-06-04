using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernel2<MarioSpriteEnum, MarioMotionEnum>
    {
        public MarioObject(Vector2 location) : base(location) { }

        protected override void Initialize()
        {
            State = new MarioState(default(Vector2));
            Sprites = new Dictionary<MarioSpriteEnum, ISprite>();
            Motions = new Dictionary<MarioMotionEnum, ObjectMotion>();

            Sprites.Add(MarioSpriteEnum.Dead, new DeadMovingUpAndDownMarioSprite());
            Sprites.Add(MarioSpriteEnum.JumpingLeftB, new JumpingLeftBMarioSprite());
            Sprites.Add(MarioSpriteEnum.JumpingLeftF, new JumpingLeftFMarioSprite());
            Sprites.Add(MarioSpriteEnum.JumpingLeftS, new JumpingLeftSMarioSprite());
            Sprites.Add(MarioSpriteEnum.JumpingRightB, new JumpingRightBMarioSprite());
            Sprites.Add(MarioSpriteEnum.JumpingRightF, new JumpingRightFMarioSprite());
            Sprites.Add(MarioSpriteEnum.JumpingRightS, new JumpingRightSMarioSprite());
            Sprites.Add(MarioSpriteEnum.RunningLeftB, new RunningLeftBMarioSprite());
            Sprites.Add(MarioSpriteEnum.RunningLeftF, new RunningLeftFMarioSprite());
            Sprites.Add(MarioSpriteEnum.RunningLeftS, new RunningLeftSMarioSprite());
            Sprites.Add(MarioSpriteEnum.RunningRightB, new RunningRightBMarioSprite());
            Sprites.Add(MarioSpriteEnum.RunningRightF, new RunningRightFMarioSprite());
            Sprites.Add(MarioSpriteEnum.RunningRightS, new RunningRightSMarioSprite());

            Motions.Add(MarioMotionEnum.LeftRight, new ObjectMotion());
            Motions.Add(MarioMotionEnum.UpDown, new ObjectMotion());
        }
    }
}