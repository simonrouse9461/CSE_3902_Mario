using System;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCollisionHandler(State<MarioSpriteState, MarioMotionState> state) : base(state)
        {
            State.BarrierDetector.AddBarrier<IObject>();
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
                State.SpriteState.ChangeColorFrequency(8);
                State.DelayCommand(state => state.SpriteState.ChangeColorFrequency(16), 200);
                State.DelayCommand(state => state.SpriteState.SetDefaultColor(), 300);
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
                    State.BarrierDetector.RemoveBarrier<Koopa>();
                    State.BarrierDetector.RemoveBarrier<Goomba>();
                    State.DelayCommand(state => state.SpriteState.SetDefaultColor(), 150);
                    State.DelayCommand(state => state.BarrierDetector.AddBarrier<Koopa>(), 150);
                    State.DelayCommand(state => state.BarrierDetector.AddBarrier<Goomba>(), 150);
                }
            }
        }
    }
}