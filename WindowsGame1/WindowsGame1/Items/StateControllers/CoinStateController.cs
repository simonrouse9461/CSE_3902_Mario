using System;

namespace MarioGame
{
    public class CoinStateController : StateControllerKernel<CoinSpriteState, CoinMotionState>
    {

        public void Generated()
        {
            MotionState.Generated();
        }

        public override void Update()
        {
            if (MotionState.StopMoving)
            {
                Core.Obj.Unload();
            }
        }

        public void Static()
        {
            MotionState.ResetStatus();
        }
    }
}