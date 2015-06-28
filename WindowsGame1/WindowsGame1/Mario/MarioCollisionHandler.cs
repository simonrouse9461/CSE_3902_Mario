using System;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCollisionHandler(State<MarioSpriteState, MarioMotionState> state) : base(state){}

        public override void Handle()
        {
            if (State.SpriteState.Dead)
                return;

            if (Detector.Detect<Fireflower>().AnyEdge.Touch)
            {
                State.SpriteState.GetFire();
            }
            if (Detector.Detect<Mushroom>().AnyEdge.Touch)
            {
                if (State.SpriteState.Small)
                {
                    State.SpriteState.BecomeBig();
                }
            }
            if (Detector.Detect<Star>().AnyEdge.Touch)
            {
                State.SpriteState.GetStarPower();
                State.SpriteState.ChangeColorFrequency(8);

                State.DelayCommand(state => state.SpriteState.ChangeColorFrequency(16), state => state.SpriteState.HaveStarPower, 200);
                State.DelayCommand(state => state.SpriteState.SetDefaultColor(), state => state.SpriteState.HaveStarPower, 300);
            }
            if ((Detector.Detect<Goomba>(goomba => goomba.Solid && goomba.Alive) + Detector.Detect<Koopa>(koopa => koopa.Solid && koopa.Alive)).AnySide.Touch)
            {
                if (State.SpriteState.Blinking) return;
                if (State.SpriteState.Small)
                {
                    State.SpriteState.BecomeDead();
                    return;
                }
                if (State.SpriteState.Big || State.SpriteState.HaveFire)
                {
                    var totalImmortalTime = 200;

                    // Enemy damage action
                    State.SpriteState.BecomeSmall();
                    State.SpriteState.BecomeBlink();
                    State.SpriteState.ChangeColorFrequency(2);
                    State.BarrierDetector.RemoveBarrier<Koopa>();
                    State.BarrierDetector.RemoveBarrier<Goomba>();

                    // Time up action
                    State.DelayCommand(state => state.SpriteState.SetDefaultColor(), state => state.SpriteState.Blinking, totalImmortalTime);
                    State.DelayCommand(state => state.BarrierDetector.AddBarrier<Koopa>(), null, totalImmortalTime);
                    State.DelayCommand(state => state.BarrierDetector.AddBarrier<Goomba>(), null, totalImmortalTime);
                }
            }
        }
    }
}