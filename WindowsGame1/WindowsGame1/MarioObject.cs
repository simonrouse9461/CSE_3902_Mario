using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernel
    {
        public MarioObject(Vector2 location) : base(location) { }

        public override void Initialize()
        {
            State = new MarioState();

            Sprites.Add(MarioSpriteEnum.RunningInPlace, new RunningInPlaceMarioSprite());
            Sprites.Add(MarioSpriteEnum.Running, new RunningLeftAndRightMarioSprite());
            Sprites.Add(MarioSpriteEnum.Dead, new DeadMovingUpAndDownMarioSprite());

            Motions.Add(MarioMotionEnum.LeftRight, );
        }
    }
}