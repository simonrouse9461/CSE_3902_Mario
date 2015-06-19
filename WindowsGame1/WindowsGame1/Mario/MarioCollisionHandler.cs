namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector<Fireflower> MarioFireflowerCollision;
        private CollisionDetector<Mushroom> MarioMushroomCollision;
        private CollisionDetector<Goomba> MarioGoombaCollision;
        private CollisionDetector<Koopa> MarioKoopaCollision;
        private CollisionDetector<Star> MarioStarCollision;


        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioFireflowerCollision = new CollisionDetector<Fireflower>(Object);
            MarioMushroomCollision = new CollisionDetector<Mushroom>(Object);
            MarioGoombaCollision = new CollisionDetector<Goomba>(Object);
            MarioKoopaCollision = new CollisionDetector<Koopa>(Object);
            MarioStarCollision = new CollisionDetector<Star>(Object);

            AddBarrier<IObject>();
        }

        public override void Handle()
        {
            if (SpriteState.IsDead())
                return;

            if (MarioFireflowerCollision.Detect().Any())
            {
                SpriteState.BecomeFire();
            }
            if (MarioMushroomCollision.Detect().Any())
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeBig();
                }
            }
            if (MarioStarCollision.Detect().Any())
            {
                SpriteState.SetStarPower(true);
            }
            if (MarioGoombaCollision.Detect(true, true).Side())
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
            if (MarioKoopaCollision.Detect(true, true).Side())
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