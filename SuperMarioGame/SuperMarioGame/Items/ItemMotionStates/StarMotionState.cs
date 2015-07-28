using System.Collections.ObjectModel;

namespace SuperMario
{
    public class StarMotionState : MotionStateKernelNew
    {

        public bool Gravity { get; private set; }

        public StarMotionState()
        {
            
                AddMotion(UniformMotion.ItemMoveLeft);
                AddMotion(UniformMotion.ItemMoveRight);
                AddMotion(new GravityMotion());
                AddMotion(UniformMotion.ItemRaiseUp);
                AddMotion(BounceUpMotion.StarMotion);
           
            LoseGravity();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
           TurnOffMotion(UniformMotion.ItemMoveLeft);
        }

        public void SetDefaultVertical()
        {
            TurnOffMotion(UniformMotion.ItemRaiseUp);
            TurnOffMotion<BounceUpMotion>();
        }

        public void Generated()
        {
            TurnOnMotion(UniformMotion.ItemRaiseUp);
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
            TurnOffMotion(UniformMotion.ItemRaiseUp);
            TurnOnMotion(UniformMotion.ItemMoveRight);
            TurnOnMotion<BounceUpMotion>();
            TurnOnMotion<GravityMotion>();
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
                TurnOffMotion(UniformMotion.ItemMoveRight);
                TurnOnMotion(UniformMotion.ItemMoveLeft);
            }
            else
            {
                TurnOffMotion(UniformMotion.ItemMoveLeft);
                TurnOnMotion(UniformMotion.ItemMoveRight);
            }
        }

        public void Bouncing()
        {
            SetDefaultVertical();
            FindMotion<BounceUpMotion>().Content.Reset();
            TurnOnMotion<BounceUpMotion>();
        }

    }
}
