namespace WindowsGame1
{
    public class NullCollisionHandler : CollisionHandlerKernelNew<ISpriteState, IMotionState>
    {
        public NullCollisionHandler(ISpriteState spriteState, IMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }
        
        protected override void Initialize() { }

        public override void Handle() { }
    }
}