using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballMotionState : MotionStateKernel
    {
        private enum OrientationEnum
        {
            Left,
            Right,
        }

        private enum ActionEnum
        {
            Null,
            Stop,
            Bounce
        }

        public FireballMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(new MoveLeftMotion().FireballVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().FireballVelocity),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new FireballBounceMotion())
            };
        }

        private OrientationEnum Orientation;
        private ActionEnum Action;
        protected override void RefreshMotionStatus()
        {
            switch (Orientation)
            {
                case OrientationEnum.Left:
                    FindMotion<MoveLeftMotion>().Toggle(true);
                    FindMotion<GravityMotion>().Toggle(true);
                    break;
                case OrientationEnum.Right:
                    FindMotion<MoveRightMotion>().Toggle(true);
                    FindMotion<GravityMotion>().Toggle(true);
                    break;
            }
            switch (Action)
            {
                case ActionEnum.Stop:
                    foreach (var motion in MotionList)
                    {
                        motion.Toggle(false);
                    }
                    break;
                case ActionEnum.Bounce:
                    FindMotion<GravityMotion>().Toggle(false);
                    FindMotion<FireballBounceMotion>().Toggle(true);
                    break;
            }
        }

        protected override void SetToDefaultState()
        {

        }

        public void GoLeft()
        {
            Orientation = OrientationEnum.Left;
        }

        public void GoRight()
        {
            Orientation = OrientationEnum.Right;
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
            Action = ActionEnum.Stop;
        }

        public void Bounce()
        {
            Action = ActionEnum.Bounce;
        }
    }
}
