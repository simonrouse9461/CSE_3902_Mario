﻿using System.Collections.ObjectModel;

namespace SuperMario
{
    public class MarioMotionState : MotionStateKernelNew
    {
        public bool Dead { get; private set; }

        public bool Gravity
        {
            get { return CheckMotion<GravityMotion>(); }
            set { }
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
            TurnOffMotion(AcceleratedMotion.MarioRight);
            TurnOffMotion(AcceleratedMotion.MarioLeft);
            TurnOffMotion<DampMotion>();
            TurnOffMotion<InertiaMotion>();
        }

        public void SetDefaultVertical()
        {
            TurnOffMotion(BounceUpMotion.MarioJump);
            TurnOffMotion(BounceUpMotion.MarioStamp);
            TurnOffMotion(UniformMotion.MarioSlipDown);
        }

        public bool DefaultHorizontal
        {
            get
            {
                return !CheckMotion(AcceleratedMotion.MarioLeft)
                       && !CheckMotion(AcceleratedMotion.MarioRight)
                       && !CheckMotion<DampMotion>()
                       && !CheckMotion<InertiaMotion>();
            }
        }

        public bool DefaultVertical
        {
            get
            {
                return !CheckMotion(BounceUpMotion.MarioJump)
                       && !CheckMotion(BounceUpMotion.MarioStamp)
                       && !CheckMotion(UniformMotion.MarioSlipDown);
            }
        }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            TurnOnMotion(AcceleratedMotion.MarioLeft);
        }

        public void GoRight()
        {
            SetDefaultHorizontal();
            TurnOnMotion(AcceleratedMotion.MarioRight);
        }

        public void Stop()
        {
            SetDefaultHorizontal();
            TurnOnMotion<DampMotion>();
        }

        public void GetInertia()
        {
            SetDefaultHorizontal();
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
            SetDefaultVertical();
            TurnOnMotion(BounceUpMotion.MarioJump);
        }

        public void Fall()
        {
            SetDefaultVertical();
            FindMotion<GravityMotion>().Content.Reset();
        }

        public void Bounce()
        {
            SetDefaultVertical();
            TurnOnMotion(BounceUpMotion.MarioStamp);
        }

        public void ObtainGravity()
        {
            TurnOnMotion<GravityMotion>();
        }

        public void LoseGravity()
        {
            TurnOffMotion<GravityMotion>();
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
        }

        public void StopSlip()
        {
            SetDefaultVertical();
        }

        public bool GoingLeft
        {
            get { return CheckMotion(AcceleratedMotion.MarioLeft); }
        }

        public bool GoingRight
        {
            get { return CheckMotion(AcceleratedMotion.MarioRight); }
        }

        public bool HaveInertia
        {
            get { return CheckMotion<InertiaMotion>(); }
        }

        public bool Stopping
        {
            get { return CheckMotion<DampMotion>(); }
        }

        public bool Jumping
        {
            get { return CheckMotion(BounceUpMotion.MarioJump); }
        }

        public bool Bouncing
        {
            get { return CheckMotion(BounceUpMotion.MarioStamp); }
        }

        public bool Sliping
        {
            get { return CheckMotion(UniformMotion.MarioSlipDown); }
        }
    }
}