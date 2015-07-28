using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CoinMotionState : MotionStateKernelNew
    {

        public CoinMotionState()
        {
            AddMotion(BounceUpMotion.CoinMotion);
        }

        public void Generated()
        {
            FindMotion<BounceUpMotion>().Toggle(true);
        }

        public bool StopMoving
        {
            get
            {
                return FindMotion<BounceUpMotion>().Content.Finish;
            }  
        }

        public void ResetStatus()
        {
            FindMotion<BounceUpMotion>().Toggle(false);
        }
    }
}
