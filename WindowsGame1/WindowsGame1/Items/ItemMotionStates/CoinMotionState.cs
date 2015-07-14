using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CoinMotionState : MotionStateKernelNew
    {

        public CoinMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(BounceUpMotion.CoinMotion)
            };
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
    }
}
