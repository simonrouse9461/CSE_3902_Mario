using System.Collections.ObjectModel;

namespace SuperMario
{
    public class MarioMotionState : MotionStateKernel
    {
        public bool Dead { get; private set; }

        public bool Gravity
        {
            get { return CheckMotion<GravityMotion>(); }
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
            AddMotion(UniformMotion.MarioSinkDown);
            AddMotion(AcceleratedMotion.GravityDecorator);

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

        public bool FullSpeed
        {
            get
            {
                return FindMotion(AcceleratedMotion.MarioLeft).Content.ReachMax
                       || FindMotion(AcceleratedMotion.MarioRight).Content.ReachMax;
            }
        }

        public bool HalfSpeed
        {
            get
            {
                return FindMotion(AcceleratedMotion.MarioLeft)
                    .Content.XReach(AcceleratedMotion.MarioLeft.MaxVelocity.X/2)
                       || FindMotion(AcceleratedMotion.MarioRight)
                           .Content.XReach(AcceleratedMotion.MarioRight.MaxVelocity.X/2);
            }
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

        public void SlowDownGravity()
        {
            TurnOnMotion(AcceleratedMotion.GravityDecorator);
        }

        public void LoseGravity()
        {
            TurnOffMotion<GravityMotion>();
            TurnOffMotion(AcceleratedMotion.GravityDecorator);
        }

        public bool GravitySlowed
        {
            get { return CheckMotion(AcceleratedMotion.GravityDecorator);}
        }

        public bool JumpFinish
        {
            get { return Jumping && FindMotion(BounceUpMotion.MarioJump).Content.Finish; }
        }

        public bool StartFall
        {
            get
            {
                return Gravity &&
                       (FindMotion<GravityMotion>().Content.Velocity.Y < GravityMotion.Max.Y
                        && FindMotion<GravityMotion>().Content.NextVelocity.Y >= GravityMotion.Max.Y
                        || DefaultVertical && FindMotion<GravityMotion>().Content.ReachMax);
            }
        }

        public void Die()
        {
            Dead = true;
            SetDefaultHorizontal();
            SetDefaultVertical();
            LoseGravity();
            TurnOnMotion(BounceUpMotion.MarioDie);
        }

        public void EnterPipe()
        {
            SetDefaultHorizontal();
            SetDefaultVertical();
            LoseGravity();
            TurnOnMotion(UniformMotion.MarioSinkDown);
        }

        public bool Sinking
        {
            get { return CheckMotion(UniformMotion.MarioSinkDown);}
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

        public bool Going
        {
            get { return GoingLeft || GoingRight; }
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