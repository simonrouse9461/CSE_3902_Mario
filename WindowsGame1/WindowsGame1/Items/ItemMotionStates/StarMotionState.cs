using System.Collections.ObjectModel;

namespace SuperMario
{
    public class StarMotionState : MotionStateKernel
    {

        public bool Gravity { get; private set; }

        public StarMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveRight),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>((UniformMotion.ItemRaiseUp)),
                new StatusSwitch<IMotion>(BounceUpMotion.StarMotion)
            };
            LoseGravity();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
            FindMotion(UniformMotion.ItemMoveLeft).Toggle(false);
        }

        public void SetDefaultVertical()
        {
            FindMotion(UniformMotion.ItemRaiseUp).Toggle(false);
            FindMotion<BounceUpMotion>().Toggle(false);
        }

        public void Generated()
        {
            FindMotion(UniformMotion.ItemRaiseUp).Toggle(true);
        }

        public void ObtainGravity()
        {
            Gravity = true;
        }

        public void LoseGravity()
        {
            Gravity = false;
        }

        public void Moving()
        {
            FindMotion(UniformMotion.ItemRaiseUp).Toggle(false);
            FindMotion(UniformMotion.ItemMoveRight).Toggle(true);
            FindMotion<BounceUpMotion>().Toggle(true);
            FindMotion<GravityMotion>().Toggle(true);
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
            }
            else
            {
                FindMotion(UniformMotion.ItemMoveLeft).Toggle(false);
                FindMotion(UniformMotion.ItemMoveRight).Toggle(true);
            }
        }

        public void Bouncing()
        {
            SetDefaultVertical();
            FindMotion<BounceUpMotion>().Content.Reset();
            FindMotion<BounceUpMotion>().Toggle(true);
        }

    }
}
