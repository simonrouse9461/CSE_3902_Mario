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
            Bounce,
            Slip
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
            AddMotion(AcceleratedMotion.MarioLeft);
            AddMotion(AcceleratedMotion.MarioRight);
            AddMotion<DampMotion>();
            AddMotion<InertiaMotion>();
            AddMotion(BounceUpMotion.MarioDie);
            AddMotion(BounceUpMotion.MarioJump);
            AddMotion(BounceUpMotion.MarioStamp);
            AddMotion<GravityMotion>();
            AddMotion(UniformMotion.MarioSlipDown);
            AddMotion(UniformMotion.MarioEnterPipe);

            SetDefaultHorizontal();
            SetDefaultVertical();
            ObtainGravity();
        }

        public void SetDefaultHorizontal()
        {
            HorizontalStatus = HorizontalEnum.Default;
            TurnOffMotion(AcceleratedMotion.MarioRight);
            TurnOffMotion(AcceleratedMotion.MarioLeft);
            TurnOffMotion<DampMotion>();
            TurnOffMotion<InertiaMotion>();
        }

        public void SetDefaultVertical()
        {
            VerticalStatus = VerticalEnum.Default;
            TurnOffMotion(BounceUpMotion.MarioJump);
            TurnOffMotion(BounceUpMotion.MarioStamp);
            TurnOffMotion(UniformMotion.MarioSlipDown);
        }

        public void GoLeft()
        {
            if (isFrozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Left;
            TurnOnMotion(AcceleratedMotion.MarioLeft);
        }

        public void GoRight()
        {
            if (isFrozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Right;
            TurnOnMotion(AcceleratedMotion.MarioRight);
        }

        public void Stop()
        {
            if (isFrozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Stop;
            TurnOnMotion<DampMotion>();
        }

        public void GetInertia()
        {
            if (isFrozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Inertia;
            TurnOnMotion<InertiaMotion>();
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
            if (isFrozen) return;
            SetDefaultVertical();
            VerticalStatus = VerticalEnum.Jump;
            TurnOnMotion(BounceUpMotion.MarioJump);
        }

        public void Fall()
        {
            if (isFrozen) return;
            SetDefaultVertical();
            FindMotion<GravityMotion>().Content.Reset();
        }

        public void Bounce()
        {
            if (isFrozen) return;
            SetDefaultVertical();
            VerticalStatus = VerticalEnum.Bounce;
            TurnOnMotion(BounceUpMotion.MarioStamp);
        }

        public void ObtainGravity()
        {
            if (isFrozen) return;
            Gravity = true;
        }

        public void LoseGravity()
        {
            if (isFrozen) return;
            Gravity = false;
        }

        public void Die()
        {
            Dead = true;
            SetDefaultHorizontal();
            SetDefaultVertical();
            LoseGravity();
            TurnOnMotion(BounceUpMotion.MarioDie);
        }

        public void Slip()
        {
            SetDefaultHorizontal();
            SetDefaultVertical();
            TurnOnMotion(UniformMotion.MarioSlipDown);
            VerticalStatus = VerticalEnum.Slip;
        }

        public void StopSlip()
        {
            SetDefaultVertical();
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

        public bool Sliping
        {
            get { return VerticalStatus == VerticalEnum.Slip; }
        }
    }
}