namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCollisionHandler(State<MarioSpriteState, MarioMotionState> state) : base(state)
        {
            AddBarrier<IObject>();
            RemoveBarrier<GreenPipeObject>();
            RemoveBarrier<Koopa>();
            RemoveBarrier<Goomba>();
        }

        public override void Handle()
        {
            if (State.SpriteState.Dead)
                return;

            if (Detector.Detect<Fireflower>().AnyEdge.Contact)
            {
                State.SpriteState.GetFire();
            }
            if (Detector.Detect<Mushroom>().AnyEdge.Contact)
            {
                if (State.SpriteState.Small)
                {
                    State.SpriteState.BecomeBig();
                }
            }
            if (Detector.Detect<Star>().AnyEdge.Contact)
            {
                State.SpriteState.GetStarPower();
            }
            if ((Detector.Detect<Goomba>(goomba => goomba.Solid && goomba.Alive)+ Detector.Detect<Koopa>(koopa => koopa.Solid && koopa.Alive)).AnySide.Contact)
            {
                if (State.SpriteState.Blinking) return;
                if (State.SpriteState.Small)
                {
                    State.SpriteState.BecomeDead();
                    return;
                }
                if (State.SpriteState.Big || State.SpriteState.HaveFire)
                {
                    State.SpriteState.BecomeSmall();
                    State.SpriteState.BecomeBlink();
                    State.SpriteState.ChangeColorFrequency(2);
                }
            }
        }
    }
}