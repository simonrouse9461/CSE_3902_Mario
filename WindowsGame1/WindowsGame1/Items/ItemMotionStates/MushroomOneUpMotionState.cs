using System.Collections.ObjectModel;

namespace MarioGame
{
    public class MushroomOneUpMotionState : MotionStateKernel
    {

        public bool Gravity { get; private set; }

        public MushroomOneUpMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveRight),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(UniformMotion.ItemRaiseUp),
                new StatusSwitch<IMotion>(BounceUpMotion.ItemBounce)
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
            FindMotion(UniformMotion.ItemRaiseUp).Toggle(false);
            FindMotion(BounceUpMotion.ItemBounce).Toggle(false);
        }

        public void Generated()
        {
            FindMotion(UniformMotion.ItemRaiseUp).Toggle(true);
        }

        public void Moving()
        {
            FindMotion(UniformMotion.ItemRaiseUp).Toggle(false);
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
                return FindMotion(UniformMotion.ItemRaiseUp).Status;
            }
        }

        public void ChangeDirection()
        {
            if (FindMotion(UniformMotion.ItemMoveRight).Status)
            {
                FindMotion(UniformMotion.ItemMoveRight).Toggle(false);
                FindMotion(UniformMotion.ItemMoveLeft).Toggle(true);
                FindMotion(BounceUpMotion.ItemBounce).Toggle(true);
            }
            else
            {
                FindMotion(UniformMotion.ItemMoveLeft).Toggle(false);
                FindMotion(UniformMotion.ItemMoveRight).Toggle(true);
                FindMotion(BounceUpMotion.ItemBounce).Toggle(true);
            }
        }
    }
}
