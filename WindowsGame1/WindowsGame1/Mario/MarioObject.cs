namespace WindowsGame1
{
    public class MarioObject : ObjectKernel<MarioSpriteState, MarioMotionState>, IMario
    {
        public MarioObject()
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState();
            CommandHandler = new MarioCommandHandler(State);
            CollisionHandler = new MarioCollisionHandler(State);

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

        public override bool Solid
        {
            get { return Alive && !SpriteState.Blinking; }
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

        public bool GoingUp
        {
            get { return MotionState.Velocity.Y < 0; }
        }
    }
}