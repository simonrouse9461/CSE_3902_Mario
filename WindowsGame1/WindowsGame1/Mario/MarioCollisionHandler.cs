namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernelNew<MarioSpriteState, MarioMotionState>
    {
        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            AddBarrier<IObject>();
        }

        public override void Handle()
        {
            if (SpriteState.Dead)
                return;

            if (Detector.Detect<Fireflower>().AnyEdge.Contact)
            {
                SpriteState.GetFire();
            }
            if (Detector.Detect<Mushroom>().AnyEdge.Contact)
            {
                if (SpriteState.Small)
                {
                    SpriteState.BecomeBig();
                }
            }
            if (Detector.Detect<Star>().AnyEdge.Contact)
            {
                SpriteState.GetStarPower();
            }
            if (Detector.Detect<Goomba>(goomba => goomba.Solid /*&& goomba.Alive*/).AnySide.Contact)
            {
                if (SpriteState.Small)
                {
                    SpriteState.BecomeDead();
                    return;
                }
                if (SpriteState.Big || SpriteState.HaveFire)
                {
                    SpriteState.BecomeSmall();
                }
            }
            if (Detector.Detect<Koopa>(koopa => koopa.Solid /*&& koopa.Alive*/).AnySide.Contact)
            {
                if (SpriteState.Small)
                {
                    SpriteState.BecomeDead();
                    return;
                }
                if (SpriteState.Big || SpriteState.HaveFire)
                {
                    SpriteState.BecomeSmall();
                }
            }
        }
    }
}