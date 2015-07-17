using System;

namespace WindowsGame1
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
                Core.Object.Unload();
            }
        }

        public void Static()
        {
            MotionState.ResetStatus();
        }
    }
}