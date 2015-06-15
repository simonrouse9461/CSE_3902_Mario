namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioObject>
    {
        private MarioSpriteState SpriteState;
        private MarioMotionState Motionstate;

        private CollisionDetector<GreenPipeObject> MarioPipeCollision;

        public MarioCollisionHandler(MarioObject mario) : base(mario) { }

        protected override void Initialize()
        {
            SpriteState = (MarioSpriteState)Object.SpriteState;
            Motionstate = (MarioMotionState)Object.MotionState;

            MarioPipeCollision = new CollisionDetector<GreenPipeObject>(Object);
        }

        public override void Handle()
        {
            if (MarioPipeCollision.Detect().Side())
            {
                SpriteState.BecomeDead();
            }
        }
    }
}