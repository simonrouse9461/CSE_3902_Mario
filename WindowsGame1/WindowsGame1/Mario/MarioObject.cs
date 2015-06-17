using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernelNew<MarioSpriteState, MarioMotionState>
    {
        public MarioObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState(location);
            CommandHandler = new MarioCommandHandler(SpriteState, MotionState);
            CollisionHandler = new MarioCollisionHandler(SpriteState, MotionState, this);

            SpriteState.BecomeSmall();
        }

        protected override void SyncState()
        {
            if (MotionState.IsHorizontalStatic())
            {
                SpriteState.Stand();
            }
            else 
            {   
                if (MotionState.IsVelRight() == SpriteState.IsRight())
                    SpriteState.Run();
                else
                    SpriteState.Break();
            }

            if (SpriteState.IsDead())
                MotionState.Dead();
        }
    }
}