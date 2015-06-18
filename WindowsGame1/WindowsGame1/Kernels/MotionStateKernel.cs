using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernel : IMotionState
    {
        protected class MotionSwitch
        {
            private readonly IMotion _motion;

            public IMotion Motion
            {
                get { return _motion; }
            }

            private bool _status;

            public bool Status
            {
                get { return _status; }
                private set { _status = value; }
            }

            public MotionSwitch(IMotion motion)
            {
                _motion = motion;
                _status = false;
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
        protected Counter Timer { get; set; }
        protected List<MotionSwitch> MotionList { get; set; }

        protected MotionStateKernel()
        {
            Initialize();

            Timer = Timer ?? new Counter();
            MotionList = MotionList ?? new List<MotionSwitch>();

            Reset();
        }

        protected abstract void Initialize();

        // This method is used to turn on motion switches base on current status.
        protected abstract void RefreshMotionList();

        // This method is used to restore all status to its default value.
        protected abstract void ResetState();

        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset();
            }
        }

        public void Update()
        {
            if (Timer.Update())
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