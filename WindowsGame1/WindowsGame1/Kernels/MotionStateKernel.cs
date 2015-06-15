using System;
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

        protected Vector2 Velocity;

        protected Counter Timer;

        protected List<MotionSwitch> MotionList;

        protected MotionStateKernel(Vector2 location)
        {
            Initialize();

            Position = location;
            Timer = Timer ?? new Counter();
            MotionList = MotionList ?? new List<MotionSwitch>();

            Reset();
        }

        protected abstract void Initialize();

        protected abstract void RefreshState();

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
                RefreshState();

                foreach (var motion in MotionList)
                {
                    if (motion.Status)
                    {
                        motion.Motion.Update();
                        Velocity = motion.Motion.GetVelocity();
                        Position += Velocity;
                    }
                }

                ResetState();
            }
        }
    }
}