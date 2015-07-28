using System.Collections.ObjectModel;

namespace SuperMario
{
    public class SuperFireballMotionState : MotionStateKernelNew
    {
        public SuperFireballMotionState()
        {
            AddMotion(UniformMotion.SuperFireballMoveLeft);
            AddMotion(UniformMotion.SuperFireballMoveRight);
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal(){
            TurnOffMotion(UniformMotion.SuperFireballMoveLeft);
            TurnOffMotion(UniformMotion.SuperFireballMoveRight);
        }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.SuperFireballMoveLeft);
        }

        public void GoRight()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.SuperFireballMoveRight);
        }

        public bool Left
        {
            get { return CheckMotion(UniformMotion.SuperFireballMoveLeft); }
        }

        public bool Right
        {
            get { return CheckMotion(UniformMotion.SuperFireballMoveRight); }
        }

    }
}
