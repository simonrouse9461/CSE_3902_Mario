namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel
    {
        private readonly MarioSpriteState _spriteState;
        private readonly MarioMotionState _motionState;
        
        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState)
        {
            _spriteState = spriteState;
            _motionState = motionState;
        }

        protected override void Initialize()
        {
            
        }

        public override void Handle()
        {
            
        }
    }
}