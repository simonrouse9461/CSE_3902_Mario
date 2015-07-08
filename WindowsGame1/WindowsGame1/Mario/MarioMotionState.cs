using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class MarioMotionState : MotionStateKernelNew
    {
        private enum HorizontalEnum
        {
            Default,
            Left,
            Right,
            Inertia,
            Stop
        }

        private enum VerticalEnum
        {
            Default,
            Jump
        }

        private HorizontalEnum HorizontalStatus;
        private VerticalEnum VerticalStatus;

        public bool Dead { get; private set; }
        public bool Gravity { get; private set; }

        public MarioMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(new AccelerateRightMotion(0.1f, 3)),
                new StatusSwitch<IMotion>(new AccelerateLeftMotion(0.1f, 3)),
                new StatusSwitch<IMotion>(new SuddenStopMotion()),
                new StatusSwitch<IMotion>(new InertiaMotion()),
                new StatusSwitch<IMotion>(new BounceUpMotion().MarioDie),
                new StatusSwitch<IMotion>(new BounceUpMotion().MarioJump),
                new StatusSwitch<IMotion>(new GravityMotion())
            };

            SetDefaultHorizontal();
            SetDefaultVertical();
            ObtainGravity();
        }

        public void SetDefaultHorizontal()
        {
            HorizontalStatus = HorizontalEnum.Default;
            FindMotion<AccelerateRightMotion>().Toggle(false);
            FindMotion<AccelerateLeftMotion>().Toggle(false);
            FindMotion<SuddenStopMotion>().Toggle(false);
            FindMotion<InertiaMotion>().Toggle(false);
        }

        public void SetDefaultVertical()
        {
            VerticalStatus = VerticalEnum.Default;
            FindMotion<BounceUpMotion>(m => m.MarioJumpVersion).Toggle(false);
        }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Left;
            FindMotion<AccelerateLeftMotion>().Toggle(true);
        }

        public void GoRight()
        {
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Right;
            FindMotion<AccelerateRightMotion>().Toggle(true);
        }

        public void Stop()
        {
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Stop;
            FindMotion<SuddenStopMotion>().Toggle(true);
        }

        public void GetInertia()
        {
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Inertia;
            FindMotion<InertiaMotion>().Toggle(true);
        }

        public void AdjustInertiaLeft()
        {
            ((InertiaMotion)FindMotion<InertiaMotion>().Content).Left();
        }

        public void AdjustInertiaRight()
        {
            ((InertiaMotion)FindMotion<InertiaMotion>().Content).Right();
        }

        public void Jump()
        {
            SetDefaultVertical();
            VerticalStatus = VerticalEnum.Jump;
            FindMotion<BounceUpMotion>(m => m.MarioJumpVersion).Toggle(true);
        }

        public void Fall()
        {
            SetDefaultVertical();
        }

        public void ObtainGravity()
        {
            Gravity = true;
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void LoseGravity()
        {
            Gravity = false;
            FindMotion<GravityMotion>().Toggle(false);
        }

        public void Die()
        {
            Dead = true;
            SetDefaultHorizontal();
            SetDefaultVertical();
            LoseGravity();
            FindMotion<BounceUpMotion>(m => m.MarioDieVersion).Toggle(true);
        }

        public bool DefaultHorizontal
        {
            get
            {
                if (HorizontalStatus == HorizontalEnum.Stop && !FindMotion<SuddenStopMotion>().Status)
                    HorizontalStatus = HorizontalEnum.Default;
                return HorizontalStatus == HorizontalEnum.Default;
            }
        }

        public bool DefaultVertical
        {
            get { return VerticalStatus == VerticalEnum.Default; }
        }

        public bool GoingLeft
        {
            get { return HorizontalStatus == HorizontalEnum.Left; }
        }

        public bool GoingRight
        {
            get { return HorizontalStatus == HorizontalEnum.Right; }
        }

        public bool HaveInertia
        {
            get { return HorizontalStatus == HorizontalEnum.Inertia; }
        }

        public bool Stopping
        {
            get
            {
                if (HorizontalStatus == HorizontalEnum.Stop && !FindMotion<SuddenStopMotion>().Status)
                    HorizontalStatus = HorizontalEnum.Default; 
                return HorizontalStatus == HorizontalEnum.Stop;
            }
        }

        public bool Jumping
        {
            get { return VerticalStatus == VerticalEnum.Jump; }
        }
    }
}