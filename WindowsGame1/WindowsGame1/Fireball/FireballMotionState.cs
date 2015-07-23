using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FireballMotionState : MotionStateKernelNew
    {
        public FireballMotionState()
        {
            AddMotion(UniformMotion.FireballMoveLeft);
            AddMotion(UniformMotion.FireballMoveRight);
            AddMotion<GravityMotion>();
            AddMotion(BounceUpMotion.FireballBounce);

            TurnOnMotion<GravityMotion>();
            SetDefaultHorizontal();
            SetDefaultVertical();
        }

        public void SetDefaultHorizontal()
        {
            TurnOffMotion(UniformMotion.FireballMoveRight);
            TurnOffMotion(UniformMotion.FireballMoveLeft);
        }

        public void SetDefaultVertical()
        {
            TurnOffMotion<BounceUpMotion>();
        }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.FireballMoveLeft);
        }

        public void GoRight()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.FireballMoveRight);
        }

        public bool Left
        {
            get { return CheckMotion(UniformMotion.FireballMoveLeft); }
        }

        public bool Right
        {
            get { return CheckMotion(UniformMotion.FireballMoveRight); }
        }

        public void Stop()
        {
            SetDefaultHorizontal();
            SetDefaultVertical();
            TurnOffMotion<GravityMotion>();
        }

        public void Bounce()
        {
            SetDefaultVertical();
            ResetMotion<BounceUpMotion>();
            TurnOnMotion<BounceUpMotion>();
        }

        public bool Bouncing
        {
            get { return CheckMotion<BounceUpMotion>(); }
        }
    }
}
