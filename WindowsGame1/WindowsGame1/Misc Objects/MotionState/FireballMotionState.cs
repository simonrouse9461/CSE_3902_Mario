using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
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
                new StatusSwitch<IMotion>(new MoveLeftMotion().FireballVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().FireballVelocity),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new BounceUpMotion().FireballBounce)
            };
            SetDefaultHorizontal();
        }

        private OrientationEnum Orientation;
        private ActionEnum Action;

        public void SetDefaultHorizontal()
        {
            FindMotion<MoveRightMotion>().Toggle(false);
            FindMotion<MoveLeftMotion>().Toggle(false);
        }

        public void GoLeft()
        {
            
            Orientation = OrientationEnum.Left;
            FindMotion<MoveLeftMotion>().Toggle(true);
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void GoRight()
        {
            Orientation = OrientationEnum.Right;
            FindMotion<MoveRightMotion>().Toggle(true);
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
            FindMotion<GravityMotion>().Toggle(false);
            Action = ActionEnum.Default;
        }

        public void Bounce()
        {
            Action = ActionEnum.Bounce;
            FindMotion<BounceUpMotion>(f => f.FireballBounceVersion).Content.Reset();
            FindMotion<BounceUpMotion>(f => f.FireballBounceVersion).Toggle(true);
        }

        public bool Bouncing
        {
            get { return Action == ActionEnum.Bounce; }
        }
    }
}
