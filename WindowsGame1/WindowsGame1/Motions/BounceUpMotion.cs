using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BounceUpMotion : MotionKernel
    {
        private Vector2 StartVelocity;
        private Vector2 Acceleration;
        private Vector2 MaxVelocity;

        private enum Version
        {
            Default,
            MarioDie,
            FireballBounce
        }

        private Version version = Version.Default;

        public override Vector2 Velocity
        {
            get
            {
                var velocity = Circulator.Phase*Acceleration + StartVelocity;
                velocity = (velocity.Y < MaxVelocity.Y) ? velocity : MaxVelocity;
                return velocity;
            }
        }

        public BounceUpMotion MarioDie
        {
            get
            {
                version = Version.MarioDie;
                StartVelocity = new Vector2(0, -3);
                Acceleration = new Vector2(0, 0.1f);
                MaxVelocity = new Vector2(0, 6);
                return this;
            }
        }

        public bool MarioDieVersion
        {
            get { return version == Version.MarioDie; }
        }

        public BounceUpMotion FireballBounce
        {
            get
            {
                version = Version.FireballBounce;
                StartVelocity = new Vector2(0, 5);
                Acceleration = new Vector2(0, 0.2f);
                MaxVelocity = new Vector2(0, 5);
                return this;
            }
        }

        public bool FireballBounceVersion
        {
            get { return version == Version.FireballBounce; }
        }
    }
}