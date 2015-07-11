using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionKernel : IMotion
    {
        protected Vector2 InitialVelocity { get; private set; }
        protected Vector2 CurrentVelocity { get; private set; }
        protected Counter Circulator { get; private set; }

        public virtual bool Finish
        {
            get { return false; }
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