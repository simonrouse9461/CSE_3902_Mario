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
            if (MotionState.VerticalStatic)
            {
                if (MotionState.HorizontalStatic)
                {
                    SpriteState.Stand();
                }
                else
                {
                    if (MotionState.MovingRight == SpriteState.Right)
                        SpriteState.Run();
                    else
                        SpriteState.Turn();
                }
            }
            else
            {
                if (MotionState.Raising)
                    SpriteState.Jump();
                else if (MotionState.Falling)
                    SpriteState.Crouch();
            }
            if (SpriteState.Dead)
                MotionState.DeadFall();
        }

        public bool Alive
        {
            get { return !SpriteState.Dead; }
        }

        public bool StarPower
        {
            get { return SpriteState.HaveStarPower; }
        }

        public bool Destructive
        {
            get { return !SpriteState.Small; }
        }
    }
}