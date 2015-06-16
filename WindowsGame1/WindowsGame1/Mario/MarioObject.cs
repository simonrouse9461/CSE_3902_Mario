using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernelNew
    {
        public MarioObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState(location);
            CommandHandler = new MarioCommandHandler((MarioSpriteState)SpriteState, (MarioMotionState)MotionState);
            CollisionHandler = new MarioCollisionHandler(this);
        }
    }
}