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

            HandleFireflower();
            HandleMushroom();
            HandleStar();
            HandleEnemy();
        }

        protected virtual void HandleMushroom()
        {
            if (Detector.Detect<Mushroom>().AnyEdge.Touch)
            {
                if (State.SpriteState.Small)
                {
                    State.SpriteState.BecomeBig();
                }
            }
        }

        protected virtual void HandleStar()
        {
            if (Detector.Detect<Star>().AnyEdge.Touch)
            {
                State.SpriteState.GetStarPower();
                State.SpriteState.ChangeColorFrequency(8);

                State.DelayCommand(() => State.SpriteState.ChangeColorFrequency(16), () => State.SpriteState.HaveStarPower, 200);
                State.DelayCommand(() => State.SpriteState.SetDefaultColor(), () => State.SpriteState.HaveStarPower, 300);
            } 
        }

        protected virtual void HandleFireflower()
        {
            if (Detector.Detect<Fireflower>().AnyEdge.Touch)
            {
                State.SpriteState.GetFire();
            }
        }

        protected virtual void HandleEnemy()
        {
            if (Detector.Detect<IEnemy>(enemy => enemy.Solid && enemy.Alive).AnySide.Touch)
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
                    State.DelayCommand(() => State.SpriteState.SetDefaultColor(), () => State.SpriteState.Blinking, totalImmortalTime);
                    State.DelayCommand(() => State.BarrierDetector.AddBarrier<Koopa>(), totalImmortalTime);
                    State.DelayCommand(() => State.BarrierDetector.AddBarrier<Goomba>(), totalImmortalTime);
                }
            }
        }
    }
}