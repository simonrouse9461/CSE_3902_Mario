using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BounceUpMotion : MotionKernel
    {
        private Vector2 StartVelocity;
        private Vector2 Acceleration;
        private Vector2 MaxVelocity;
        private bool InvolveGravity;
        private bool FinishWhenMax;

        private enum Version
        {
            Default,
            Mariojump,
            MarioDie,
            FireballBounce
        }

        private Version version = Version.Default;

        public override int VersionCode
        {
            get { return (int)version; }
        }

        public override Vector2 Velocity
        {
            get
            {
                var velocity = Circulator.Phase*Acceleration + StartVelocity -
                               GravityMotion.MaxVelocity*(InvolveGravity ? 1 : 0);
                velocity = (velocity.Y < (MaxVelocity - GravityMotion.MaxVelocity*(InvolveGravity ? 1 : 0)).Y)
                    ? velocity
                    : MaxVelocity - GravityMotion.MaxVelocity*(InvolveGravity ? 1 : 0);
                return velocity;
            }
        }

        public override bool Finish
        {
            get { return (Velocity.Y >= (MaxVelocity - GravityMotion.MaxVelocity*(InvolveGravity ? 1 : 0)).Y) && FinishWhenMax; }
        }

        public BounceUpMotion MarioJump
        {
            get
            {
                version = Version.Mariojump;
                StartVelocity = new Vector2(0, -6);
                Acceleration = new Vector2(0, 0.17f);
                MaxVelocity = default(Vector2);
                InvolveGravity = true;
                FinishWhenMax = true;
                return this;
            }
        }

        public BounceUpMotion MarioDie
        {
            get
            {
                version = Version.MarioDie;
                StartVelocity = new Vector2(0, -3);
                Acceleration = new Vector2(0, 0.1f);
                MaxVelocity = GravityMotion.MaxVelocity;
                InvolveGravity = false;
                FinishWhenMax = false;
                return this;
            }
        }

        public BounceUpMotion FireballBounce
        {
            get
            {
                version = Version.FireballBounce;
                StartVelocity = new Vector2(0, -2.7f);
                Acceleration = new Vector2(0, 0.2f);
                MaxVelocity = GravityMotion.MaxVelocity;
                InvolveGravity = true;
                FinishWhenMax = true;
                return this;
            }
        }
    }
}