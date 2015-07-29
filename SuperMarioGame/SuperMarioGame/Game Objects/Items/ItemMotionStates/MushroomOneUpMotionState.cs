using System.Collections.ObjectModel;

namespace SuperMario
{
    public class MushroomOneUpMotionState : MotionStateKernel
    {

        public bool Gravity { get; private set; }

        public MushroomOneUpMotionState()
        {
            
                AddMotion(UniformMotion.ItemMoveLeft);
                AddMotion(UniformMotion.ItemMoveRight);
                AddMotion(new GravityMotion());
                AddMotion(UniformMotion.ItemRaiseUp);
                AddMotion(BounceUpMotion.ItemBounce);
            
            LoseGravity();
            SetDefaultHorizontal();
            SetDefaultVertical();
        }

        public void SetDefaultHorizontal()
        {
            TurnOffMotion(UniformMotion.ItemMoveLeft);
            TurnOffMotion(UniformMotion.ItemMoveRight);
        }

        public void SetDefaultVertical()
        {
            TurnOffMotion(UniformMotion.ItemRaiseUp);
            TurnOffMotion(BounceUpMotion.ItemBounce);
        }

        public void Generated()
        {
            TurnOnMotion(UniformMotion.ItemRaiseUp);
        }

        public void Moving()
        {
            TurnOffMotion(UniformMotion.ItemRaiseUp);
            TurnOnMotion(UniformMotion.ItemMoveRight);
        }

        public void ObtainGravity()
        {
            TurnOnMotion<GravityMotion>();
            Gravity = true;
        }

        public void LoseGravity()
        {
            TurnOffMotion<GravityMotion>();
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
                TurnOffMotion(UniformMotion.ItemMoveRight);
                TurnOnMotion(UniformMotion.ItemMoveLeft);
                TurnOnMotion(BounceUpMotion.ItemBounce);
            }
            else
            {
                TurnOffMotion(UniformMotion.ItemMoveLeft);
                TurnOnMotion(UniformMotion.ItemMoveRight);
                TurnOnMotion(BounceUpMotion.ItemBounce);
            }
        }
    }
}
