using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionKernel : IMotion
    {
        protected Vector2 InitialVelocity;

        protected Counter Circulator;
        
        protected MotionKernel(int period = 0)
        {
            Circulator = new Counter(period);
            Reset();
        }

        public virtual void Reset(Vector2 initial = default(Vector2))
        {
            InitialVelocity = initial;
            Circulator.Reset(); 
        }

        public void Update(int phase = -1)
        {
            Circulator.Update(phase);
        }

        public abstract Vector2 GetVelocity();
    }
}