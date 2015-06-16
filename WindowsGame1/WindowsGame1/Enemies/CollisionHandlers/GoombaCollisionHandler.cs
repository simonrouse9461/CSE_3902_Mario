namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernel
    {
        private readonly GoombaSpriteState _spriteState;
        private readonly GoombaMotionState _motionState;
        
        public GoombaCollisionHandler(GoombaSpriteState spriteState, GoombaMotionState motionState)
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