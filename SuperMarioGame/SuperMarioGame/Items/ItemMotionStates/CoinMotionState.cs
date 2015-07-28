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
            TurnOnMotion<BounceUpMotion>();
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
            TurnOffMotion<BounceUpMotion>();
        }
    }
}
