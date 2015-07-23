using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class AcceleratedMotion : MotionKernel
    {
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

        // Versions

        public static AcceleratedMotion MarioLeft
        {
            get
            {
                return new AcceleratedMotion
                {
                    version = Version.MarioLeft,
                    Acceleration = new Vector2(-0.1f, 0),
                    MaxVelocity = new Vector2(-3, 0)
                };
            }
        }

        public static AcceleratedMotion MarioRight
        {
            get
            {
                return new AcceleratedMotion
                {
                    version = Version.MarioRight,
                    Acceleration = new Vector2(0.1f, 0),
                    MaxVelocity = new Vector2(3, 0)
                };
            }
        }
    }
}