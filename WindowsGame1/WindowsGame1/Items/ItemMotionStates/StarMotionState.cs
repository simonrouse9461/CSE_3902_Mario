using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class StarMotionState : MotionStateKernelNew
    {

        public bool Gravity { get; private set; }

        public StarMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(MoveLeftMotion.ItemVelocity),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new RaiseUpMotion())
            };
            LoseGravity();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
            FindMotion<MoveLeftMotion>().Toggle(false);
        }

        public void SetDefaultVertical()
        {
            FindMotion<RaiseUpMotion>().Toggle(false);
        }

        public void Generated()
        {
            FindMotion<RaiseUpMotion>().Toggle(true);
        }

        public void ObtainGravity()
        {
            Gravity = true;
        }

        public void LoseGravity()
        {
            Gravity = false;
        }

    }
}
