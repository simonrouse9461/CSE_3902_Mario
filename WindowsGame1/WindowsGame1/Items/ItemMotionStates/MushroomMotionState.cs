using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class MushroomMotionState : MotionStateKernelNew
    {

        public bool Gravity { get; private set; }

        public MushroomMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(MoveLeftMotion.ItemVelocity),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new RaiseUpMotion())
            };
            LoseGravity();
            SetDefaultHorizontal();
            SetDefaultVertical();
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

        public void Moving()
        {
            FindMotion<RaiseUpMotion>().Toggle(false);
            FindMotion<MoveLeftMotion>().Toggle(true);
            ObtainGravity();
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
