namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernel<Goomba>
    {
        private readonly GoombaSpriteState _spriteState;
        private readonly GoombaMotionState _motionState;
        
        
        public GoombaCollisionHandler(Goomba goomba) : base(goomba) { }

        protected override void Initialize()
        {
            
        }

        public override void Handle()
        {
            
        }
    }
}