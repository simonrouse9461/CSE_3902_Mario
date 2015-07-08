using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class AccelerateMotion : MotionKernel
    {
        private Vector2 Acceleration;

        private Vector2 MaxVelocity;

        private enum Version
        {
            Default,
            MarioLeft,
            MarioRight
        }

        private Version version = Version.Default;

        public override int VersionCode
        {
            get { return (int) version; }
        }

        public override Vector2 Velocity
        {
            get
            {
                var velocity = Circulator.Phase*Acceleration + InitialVelocity;
                return Math.Abs(velocity.X) >= Math.Abs(MaxVelocity.X) ? MaxVelocity : velocity;
            }
        }

        public AccelerateMotion MarioLeft
        {
            get
            {
                version = Version.MarioLeft;
                Acceleration = new Vector2(-0.1f, 0);
                MaxVelocity = new Vector2(-3, 0);
                return this;
            }
        }

        public AccelerateMotion MarioRight
        {
            get
            {
                version = Version.MarioRight;
                Acceleration = new Vector2(0.1f, 0);
                MaxVelocity = new Vector2(3, 0);
                return this;
            }
        }
    }
}