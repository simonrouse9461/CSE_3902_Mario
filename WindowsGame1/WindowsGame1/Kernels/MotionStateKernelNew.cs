using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernelNew : IMotionState
    {
        protected class MotionSwitch
        {
            private readonly IMotion motion;

            public IMotion Motion
            {
                get { return motion; }
            }

            private bool status;

            public bool Status
            {
                get { return status; }
                private set { status = value; }
            }

            public MotionSwitch(IMotion motionSwitch)
            {
                motion = motionSwitch;
                status = false;
            }

            public void Toggle(bool status)
            {
                Status = status;
            }

            public void Reset(Vector2 initial = default(Vector2))
            {
                Motion.Reset(initial);
                Status = false;
            }
        }

        public Vector2 Position { get; set; }

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        protected Vector2 Velocity { get; set; }
        protected Counter UpdateTimer { get; set; }
        protected List<MotionSwitch> MotionList { get; set; }

        protected MotionStateKernelNew()
        {
            UpdateTimer =  new Counter();
            Velocity = default(Vector2);
        }

        // This method is used to turn on motion switches base on current status.
        protected abstract void RefreshMotionList();

        // This method is used to restore all status to its default value.
        protected abstract void ResetState();

        public void Reset()
        {
            UpdateTimer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset();
            }
        }

        public void Update()
        {
            if (MotionList == null) return;
            if (UpdateTimer.Update())
            {
                foreach (var motion in MotionList)
                {
                    motion.Toggle(false);
                }

                RefreshMotionList();

                Velocity = default(Vector2);

                foreach (var motion in MotionList)
                {
                    if (motion.Status && !motion.Motion.Finish)
                    {
                        motion.Motion.Update();
                        Velocity += motion.Motion.Velocity;
                    }
                    else
                    {
                        motion.Reset(Velocity);
                    }
                }

                Position += Velocity;

                ResetState();
            }
        }
    }
}