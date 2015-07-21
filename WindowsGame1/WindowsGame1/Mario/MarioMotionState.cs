using System.Collections.ObjectModel;

namespace MarioGame
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
            Jump,
            Bounce
        }

        private HorizontalEnum HorizontalStatus { get; set; }
        private VerticalEnum VerticalStatus { get; set; }

        public bool Dead { get; private set; }

        public bool Gravity
        {
            get { return FindMotion<GravityMotion>().Status; }
            set { FindMotion<GravityMotion>().Toggle(value); }
        }

        public MarioMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(AcceleratedMotion.MarioLeft),
                new StatusSwitch<IMotion>(AcceleratedMotion.MarioRight),
                new StatusSwitch<IMotion>(new DampMotion()),
                new StatusSwitch<IMotion>(new InertiaMotion()),
                new StatusSwitch<IMotion>(BounceUpMotion.MarioDie),
                new StatusSwitch<IMotion>(BounceUpMotion.MarioJump),
                new StatusSwitch<IMotion>(BounceUpMotion.MarioStamp),
                new StatusSwitch<IMotion>(new GravityMotion())
            };

            SetDefaultHorizontal();
            SetDefaultVertical();
            ObtainGravity();
        }

        public void SetDefaultHorizontal()
        {
            HorizontalStatus = HorizontalEnum.Default;
            FindMotion(AcceleratedMotion.MarioRight).Toggle(false);
            FindMotion(AcceleratedMotion.MarioLeft).Toggle(false);
            FindMotion<DampMotion>().Toggle(false);
            FindMotion<InertiaMotion>().Toggle(false);
        }

        public void SetDefaultVertical()
        {
            VerticalStatus = VerticalEnum.Default;
            FindMotion(BounceUpMotion.MarioJump).Toggle(false);
        }

        public void GoLeft()
        {
            if (Frozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Left;
            FindMotion(AcceleratedMotion.MarioLeft).Toggle(true);
        }

        public void GoRight()
        {
            if (Frozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Right;
            FindMotion(AcceleratedMotion.MarioRight).Toggle(true);
        }

        public void Stop()
        {
            if (Frozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Stop;
            FindMotion<DampMotion>().Toggle(true);
        }

        public void GetInertia()
        {
            if (Frozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Inertia;
            FindMotion<InertiaMotion>().Toggle(true);
        }

        public void AdjustInertiaLeft()
        {
            ((InertiaMotion)FindMotion<InertiaMotion>().Content).LeftAdjust();
        }

        public void AdjustInertiaRight()
        {
            ((InertiaMotion)FindMotion<InertiaMotion>().Content).RightAdjust();
        }

        public void Jump()
        {
            if (Frozen) return;
            SetDefaultVertical();
            VerticalStatus = VerticalEnum.Jump;
            FindMotion(BounceUpMotion.MarioJump).Toggle(true);
        }

        public void Fall()
        {
            if (Frozen) return;
            SetDefaultVertical();
            FindMotion<GravityMotion>().Content.Reset();
        }

        public void Bounce()
        {
            if (Frozen) return;
            SetDefaultVertical();
            VerticalStatus = VerticalEnum.Bounce;
            FindMotion(BounceUpMotion.MarioStamp).Toggle(true);
        }

        public void ObtainGravity()
        {
            if (Frozen) return;
            Gravity = true;
        }

        public void LoseGravity()
        {
            if (Frozen) return;
            Gravity = false;
        }

        public void Die()
        {
            Dead = true;
            SetDefaultHorizontal();
            SetDefaultVertical();
            LoseGravity();
            FindMotion(BounceUpMotion.MarioDie).Toggle(true);
        }

        public bool DefaultHorizontal
        {
            get
            {
                if (HorizontalStatus == HorizontalEnum.Stop && !FindMotion<DampMotion>().Status)
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
                if (HorizontalStatus == HorizontalEnum.Stop && !FindMotion<DampMotion>().Status)
                    HorizontalStatus = HorizontalEnum.Default; 
                return HorizontalStatus == HorizontalEnum.Stop;
            }
        }

        public bool Jumping
        {
            get { return VerticalStatus == VerticalEnum.Jump; }
        }

        public bool Bouncing
        {
            get { return VerticalStatus == VerticalEnum.Bounce; }
        }
    }
}