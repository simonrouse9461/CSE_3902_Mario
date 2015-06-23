using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernelNew : IMotionState
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        protected Counter Timer { get; set; }
        protected List<StatusSwitch<IMotion>> MotionList { get; set; }

        protected MotionStateKernelNew()
        {
            Timer =  new Counter();
            Velocity = default(Vector2);
        }

        // This method is used to turn on motion switches base on current status.
        protected abstract void RefreshMotionList();

        // This method is used to restore all status to its default value.
        protected abstract void ResetState();

        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.Reset());
            }
        }

        public void Update()
        {
            if (MotionList == null) return;
            if (Timer.Update())
            {
                foreach (var motion in MotionList)
                {
                    motion.Toggle(false);
                }

                Velocity = default(Vector2);

                RefreshMotionList();

                foreach (var motion in MotionList)
                {
                    if (motion.Status && !motion.Content.Finish)
                    {
                        motion.Content.Update();
                        Velocity += motion.Content.Velocity;
                    }
                    else
                    {
                        motion.Reset(m => m.Reset(Velocity));
                    }
                }

                Position += Velocity;

                ResetState();
            }
        }
    }
}