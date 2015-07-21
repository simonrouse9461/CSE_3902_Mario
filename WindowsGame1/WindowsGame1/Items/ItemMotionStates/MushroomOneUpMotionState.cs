using System.Collections.ObjectModel;

namespace MarioGame
{
    public class MushroomOneUpMotionState : MotionStateKernelNew
    {

        public bool Gravity { get; private set; }

        public MushroomOneUpMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveRight),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new RaiseUpMotion())
            };
            LoseGravity();
            SetDefaultHorizontal();
            SetDefaultVertical();
        }

        public void SetDefaultHorizontal()
        {
            FindMotion(UniformMotion.ItemMoveLeft).Toggle(false);
            FindMotion(UniformMotion.ItemMoveRight).Toggle(false);
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
            FindMotion(UniformMotion.ItemMoveRight).Toggle(true);
        }

        public void ObtainGravity()
        {
            FindMotion<GravityMotion>().Toggle(true);
            Gravity = true;
        }

        public void LoseGravity()
        {
            FindMotion<GravityMotion>().Toggle(false);
            Gravity = false;
        }

        public bool isGenerating
        {
            get
            {
                return FindMotion<RaiseUpMotion>().Status;
            }
        }

        public void ChangeDirection()
        {
            if (FindMotion(UniformMotion.ItemMoveRight).Status)
            {
                FindMotion(UniformMotion.ItemMoveRight).Toggle(false);
                FindMotion(UniformMotion.ItemMoveLeft).Toggle(true);
            }
            else
            {
                FindMotion(UniformMotion.ItemMoveLeft).Toggle(false);
                FindMotion(UniformMotion.ItemMoveRight).Toggle(true);
            }
        }
    }
}
