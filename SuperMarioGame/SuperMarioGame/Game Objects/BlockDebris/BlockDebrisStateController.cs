using SuperMario;

namespace SuperMario
{
    public class BlockDebrisStateController : StateControllerKernel<BlockDebrisSpriteState, BlockDebrisMotionState>
    {
        public void UpperLeft()
        {
            MotionState.GoUpperLeft();
        }

        public void LowerLeft()
        {
            MotionState.GoLowerLeft();
        }

        public void UpperRight()
        {
            MotionState.GoUpperRight();
        }

        public void LowerRight()
        {
            MotionState.GoLowerRight();
        }
    }
}