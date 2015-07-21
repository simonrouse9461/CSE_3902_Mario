using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FireballMotionState : MotionStateKernelNew
    {
        private enum OrientationEnum
        {
            Left,
            Right,
        }

        private enum ActionEnum
        {
            Default,
            Stop,
            Bounce
        }

        public FireballMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(UniformMotion.FireballMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.FireballMoveRight),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(BounceUpMotion.FireballBounce)
            };

            SetDefaultHorizontal();
            SetDefaultVertical();
        }

        private OrientationEnum Orientation;
        private ActionEnum Action;

        public void SetDefaultHorizontal()
        {
            FindMotion(UniformMotion.FireballMoveRight).Toggle(false);
            FindMotion(UniformMotion.FireballMoveLeft).Toggle(false);
        }

        public void SetDefaultVertical()
        {
            FindMotion<BounceUpMotion>().Toggle(false);
        }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            Orientation = OrientationEnum.Left;
            FindMotion(UniformMotion.FireballMoveLeft).Toggle(true);
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void GoRight()
        {
            SetDefaultHorizontal();
            Orientation = OrientationEnum.Right;
            FindMotion(UniformMotion.FireballMoveRight).Toggle(true);
            FindMotion<GravityMotion>().Toggle(true);
        }

        public bool Left
        {
            get { return Orientation == OrientationEnum.Left; }
        }

        public bool Right
        {
            get { return Orientation == OrientationEnum.Right; }
        }

        public void Stop()
        {
            SetDefaultHorizontal();
            SetDefaultVertical();
            FindMotion<GravityMotion>().Toggle(false);
            Action = ActionEnum.Default;
        }

        public void Bounce()
        {
            SetDefaultVertical();
            Action = ActionEnum.Bounce;
            FindMotion<BounceUpMotion>().Content.Reset();
            FindMotion<BounceUpMotion>().Toggle(true);
        }

        public bool Bouncing
        {
            get { return Action == ActionEnum.Bounce; }
        }
    }
}
