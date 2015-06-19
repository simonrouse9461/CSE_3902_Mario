namespace WindowsGame1
{
    public class MarioObject : ObjectKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioObject(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState();
            CommandHandler = new MarioCommandHandler(SpriteState, MotionState);
            CollisionHandler = new MarioCollisionHandler(SpriteState, MotionState, this);

            SpriteState.BecomeSmall();
        }

        protected override void SyncState()
        {
            if (MotionState.IsVerticalStatic())
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
            }
            else
            {
                if (MotionState.IsRaise())
                    SpriteState.Jump();
                else if (MotionState.IsFall())
                    SpriteState.Crouch();
            }
            if (SpriteState.IsDead())
                MotionState.Dead();
        }
    }
}