using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernelNew
    {
        public MarioObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState(location);
            CommandHandler = new MarioCommandHandler((MarioSpriteState)SpriteState, (MarioMotionState)MotionState);
            CollisionHandler = new MarioCollisionHandler((MarioSpriteState)SpriteState, (MarioMotionState)MotionState);
        }
    }
}