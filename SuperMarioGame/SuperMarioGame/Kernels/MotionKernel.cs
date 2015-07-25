using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class MotionKernel : IMotion
    {
        protected Counter Circulator { get; private set; }

        // The velocity of the object when this motion is turned on
        protected Vector2 InitialVelocity { get; private set; }
        // The current velocity of the object
        protected Vector2 CurrentVelocity { get; private set; }

        public Vector2 StartVelocity { get; protected set; }
        public Vector2 MaxVelocity { get; protected set; }
        public Vector2 Acceleration { get; protected set; }

        public bool Status { get; protected set; }

        public virtual bool Finish
        {
            get { return false; }
        }

        public bool ReachMax
        {
            get { return Velocity == MaxVelocity; }
        }

        public bool XReach(float speed)
        {
            return Velocity.X/speed >= 1;
        }

        public bool YReach(float speed)
        {
            return Velocity.Y/speed >= 1;
        }

        public abstract Vector2 Velocity { get; }

        protected MotionKernel(int period = 0)
        {
            Circulator = new Counter(period);
        }

        public virtual int VersionCode
        {
            get { return 0; }
        }

        public bool SameVersion(IMotion motion)
        {
            return motion.GetType() == GetType() && motion.VersionCode == VersionCode;
        }

        public void SetInitialVelocity(Vector2 velocity = default (Vector2))
        {
            InitialVelocity = velocity;
        }

        public void SetCurrentVelocity(Vector2 velocity = default (Vector2))
        {
            CurrentVelocity = velocity;
        }

        public virtual void Reset(Vector2 velocity)
        {
            SetInitialVelocity(velocity);
            SetCurrentVelocity(velocity);
            Circulator.Reset();
        }

        public virtual void Reset()
        {
            Reset(default(Vector2));
        }

        public void ResetX(float speed = 0)
        {
            Reset(new Vector2(speed, CurrentVelocity.Y));
        }

        public void ResetY(float speed = 0)
        {
            Reset(new Vector2(CurrentVelocity.X, speed));
        }

        public void Update(int phase = -1)
        {
            Circulator.Update(phase);
        }
    }
}