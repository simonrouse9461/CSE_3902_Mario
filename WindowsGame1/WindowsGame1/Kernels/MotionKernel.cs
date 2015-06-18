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
            Reset();
        }

        public virtual void Reset(Vector2 initialVelocity = default(Vector2))
        {
            InitialVelocity = initialVelocity;
            Circulator.Reset(); 
        }

        public void Update(int phase = -1)
        {
            Circulator.Update(phase);
        }
    }
}