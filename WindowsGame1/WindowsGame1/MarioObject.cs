using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernel<MarioSpriteEnum, MarioMotionEnum>
    {
        public MarioObject(Vector2 location) : base(location) { }

        protected override void Initialize()
        {
            State = new ObjectState<MarioSpriteEnum, MarioMotionEnum>(default(Vector2));
            Sprites = new Dictionary<MarioSpriteEnum, ISprite>();
            Motions = new Dictionary<MarioMotionEnum, ObjectMotion>();

            Sprites.Add(MarioSpriteEnum.RunningInPlace, new RunningInPlaceMarioSprite());
            Sprites.Add(MarioSpriteEnum.Running, new RunningLeftAndRightMarioSprite());
            Sprites.Add(MarioSpriteEnum.Dead, new DeadMovingUpAndDownMarioSprite());

            Motions.Add(MarioMotionEnum.LeftRight, new ObjectMotion());
            Motions.Add(MarioMotionEnum.UpDown, new ObjectMotion());
        }
    }
}