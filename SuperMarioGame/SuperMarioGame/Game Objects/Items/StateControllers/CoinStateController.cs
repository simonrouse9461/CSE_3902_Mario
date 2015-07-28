using System;

namespace SuperMario
{
    public class CoinStateController : StateControllerKernelNew<CoinSpriteState, CoinMotionState>
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