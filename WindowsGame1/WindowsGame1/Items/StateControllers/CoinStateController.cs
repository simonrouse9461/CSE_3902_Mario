using System;

namespace WindowsGame1
{
    public class CoinStateController : StateControllerKernel<CoinSpriteState, CoinMotionState>
    {

        public void Generated()
        {
            MotionState.Generated();

        }
    }
}