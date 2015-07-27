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
            MarioRight,
            Gravity,
        }

        private Version version = Version.Default;

        public override int VersionCode
        {
            get { return (int) version; }
        }

        private bool UseInitialVelocity { get; set; }

        public override Vector2 GetVelocity(int phase)
        {
            var initial = UseInitialVelocity ? InitialVelocity : StartVelocity;
            var velocity = phase*Acceleration + initial;
            var condition = Math.Abs(Acceleration.X) <= 0.001 && (MaxVelocity - velocity).Y/Acceleration.Y <= 0
                            || Math.Abs(Acceleration.Y) <= 0.001 && (MaxVelocity - velocity).X/Acceleration.X <= 0;
            return condition ? MaxVelocity : velocity;
        }

        // Versions

        public static AcceleratedMotion MarioLeft
        {
            get
            {
                return new AcceleratedMotion
                {
                    version = Version.MarioLeft,
                    UseInitialVelocity = true,
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
                    UseInitialVelocity = true,
                    Acceleration = new Vector2(0.1f, 0),
                    MaxVelocity = new Vector2(3, 0)
                };
            }
        }

        public static AcceleratedMotion GravityDecorator
        {
            get
            {
                return new AcceleratedMotion
                {
                    version = Version.Gravity,
                    UseInitialVelocity = false,
                    StartVelocity = -GravityMotion.Max,
                    Acceleration = new Vector2(0, 0.8f),
                    MaxVelocity = default(Vector2)
                };
            }
        }
    }
}