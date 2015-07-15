﻿using System.Collections.ObjectModel;

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
            Jump,
            Bounce
        }

        private HorizontalEnum HorizontalStatus;
        private VerticalEnum VerticalStatus;

        public bool Dead { get; private set; }
        public bool Gravity { get; private set; }
        public bool Frozen { get; private set; }

        public MarioMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(AccelerateMotion.MarioLeft),
                new StatusSwitch<IMotion>(AccelerateMotion.MarioRight),
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
            FindMotion(AccelerateMotion.MarioRight).Toggle(false);
            FindMotion(AccelerateMotion.MarioLeft).Toggle(false);
            FindMotion<DampMotion>().Toggle(false);
            FindMotion<InertiaMotion>().Toggle(false);
        }

        public void SetDefaultVertical()
        {
            VerticalStatus = VerticalEnum.Default;
            FindMotion(BounceUpMotion.MarioJump).Toggle(false);
        }

        public void Freeze()
        {
            SetDefaultHorizontal();
            SetDefaultVertical();
            LoseGravity();
            Frozen = true;
        }

        public void Restore()
        {
            Frozen = false;
        }

        public void GoLeft()
        {
            if (Frozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Left;
            FindMotion(AccelerateMotion.MarioLeft).Toggle(true);
        }

        public void GoRight()
        {
            if (Frozen) return;
            SetDefaultHorizontal();
            HorizontalStatus = HorizontalEnum.Right;
            FindMotion(AccelerateMotion.MarioRight).Toggle(true);
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
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void LoseGravity()
        {
            if (Frozen) return;
            Gravity = false;
            FindMotion<GravityMotion>().Toggle(false);
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