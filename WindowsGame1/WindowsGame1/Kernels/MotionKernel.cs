using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionKernel : IMotion
    {
        protected Vector2 InitialVelocity { get; set; }
        protected Counter Circulator { get; set; }

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

        public virtual void Reset(Vector2 initialVelocity = default(Vector2))
        {
            InitialVelocity = initialVelocity;
            Circulator.Reset(); 
        }

        public void ResetX(float speed = 0)
        {
            InitialVelocity = new Vector2(speed, InitialVelocity.Y);
            Circulator.Reset();
        }

        public void ResetY(float speed = 0)
        {
            InitialVelocity = new Vector2(InitialVelocity.Y, speed);
            Circulator.Reset();
        }

        public void Update(int phase = -1)
        {
            Circulator.Update(phase);
        }
    }
}