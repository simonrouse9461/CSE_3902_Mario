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

            if (CollisionDetector.Detect<Fireflower>().Any())
            {
                SpriteState.BecomeFire();
            }
            if (CollisionDetector.Detect<Mushroom>().Any())
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeBig();
                }
            }
            if (CollisionDetector.Detect<Star>().Any())
            {
                SpriteState.SetStarPower(true);
            }
            if (CollisionDetector.Detect<Goomba>(goomba => goomba.Solid && goomba.Solid).Side())
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
            if (CollisionDetector.Detect<Koopa>(koopa => koopa.Solid && koopa.Solid).Side())
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