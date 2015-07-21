using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class AccelerateMotion : MotionKernel
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

        public static AccelerateMotion MarioLeft
        {
            get
            {
                return new AccelerateMotion
                {
                    version = Version.MarioLeft,
                    Acceleration = new Vector2(-0.1f, 0),
                    MaxVelocity = new Vector2(-3, 0)
                };
            }
        }

        public static AccelerateMotion MarioRight
        {
            get
            {
                return new AccelerateMotion
                {
                    version = Version.MarioRight,
                    Acceleration = new Vector2(0.1f, 0),
                    MaxVelocity = new Vector2(3, 0)
                };
            }
        }
    }
}