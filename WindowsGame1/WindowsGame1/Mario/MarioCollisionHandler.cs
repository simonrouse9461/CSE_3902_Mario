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
            if (SpriteState.IsDead())
                return;

            if (CollisionDetector.Detect<Fireflower>().AnyEdge.Contact)
            {
                SpriteState.BecomeFire();
            }
            if (CollisionDetector.Detect<Mushroom>().AnyEdge.Contact)
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeBig();
                }
            }
            if (CollisionDetector.Detect<Star>().AnyEdge.Contact)
            {
                SpriteState.SetStarPower(true);
            }
            if (CollisionDetector.Detect<Goomba>(goomba => goomba.Solid /*&& goomba.Alive*/).AnySide.Contact)
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeDead();
                    return;
                }
                if (SpriteState.IsBig() || SpriteState.IsFire())
                {
                    SpriteState.BecomeSmall();
                }
            }
            if (CollisionDetector.Detect<Koopa>(koopa => koopa.Solid /*&& koopa.Alive*/).AnySide.Contact)
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeDead();
                    return;
                }
                if (SpriteState.IsBig() || SpriteState.IsFire())
                {
                    SpriteState.BecomeSmall();
                }
            }
        }
    }
}