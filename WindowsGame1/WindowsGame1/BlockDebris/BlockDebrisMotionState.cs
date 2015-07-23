namespace MarioGame
{
    public class BlockDebrisMotionState : MotionStateKernelNew
    {
        public BlockDebrisMotionState()
        {
            AddMotion(BounceUpMotion.BlockDebrisHigh);
            AddMotion(BounceUpMotion.BlockDebrisLow);
            AddMotion(UniformMotion.BlockDebrisLeft);
            AddMotion(UniformMotion.BlockDebrisRight);   
        }

        public void GoUpperLeft()
        {
            TurnOnMotion(UniformMotion.BlockDebrisLeft);
            TurnOnMotion(BounceUpMotion.BlockDebrisHigh);
        }

        public void GoLowerLeft()
        {
            TurnOnMotion(UniformMotion.BlockDebrisLeft);
            TurnOnMotion(BounceUpMotion.BlockDebrisLow);
        }

        public void GoUpperRight()
        {
            TurnOnMotion(UniformMotion.BlockDebrisRight);
            TurnOnMotion(BounceUpMotion.BlockDebrisHigh);
        }

        public void GoLowerRight()
        {
            TurnOnMotion(UniformMotion.BlockDebrisRight);
            TurnOnMotion(BounceUpMotion.BlockDebrisLow);
        }
    }
}