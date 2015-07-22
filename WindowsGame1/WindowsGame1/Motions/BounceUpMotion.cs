using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class BounceUpMotion : MotionKernel
    {
        private bool InvolveGravity { get; set; }
        private bool FinishWhenMax { get; set; }

        private enum Version
        {
            Default,
            Mariojump,
            MarioDie,
            MarioBounce,
            FireballBounce,
            EnemyFlip,
            Coin,
            Star,
            BlockHit,
            ItemBounce
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
                               GravityMotion.Max*(InvolveGravity ? 1 : 0);
                velocity = (velocity.Y < (MaxVelocity - GravityMotion.Max*(InvolveGravity ? 1 : 0)).Y)
                    ? velocity
                    : MaxVelocity - GravityMotion.Max*(InvolveGravity ? 1 : 0);
                return velocity;
            }
        }

        public override bool Finish
        {
            get
            {
                return (Velocity.Y >= (MaxVelocity - GravityMotion.Max*(InvolveGravity ? 1 : 0)).Y) && FinishWhenMax;
            }
        }

        // Versions

        public static BounceUpMotion MarioJump
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.Mariojump,
                    StartVelocity = new Vector2(0, -7.2f),
                    Acceleration = new Vector2(0, 0.2f),
                    MaxVelocity = default(Vector2),
                    InvolveGravity = true,
                    FinishWhenMax = true
                };
            }
        }

        public static BounceUpMotion MarioDie
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.MarioDie,
                    StartVelocity = new Vector2(0, -3),
                    Acceleration = new Vector2(0, 0.1f),
                    MaxVelocity = GravityMotion.Max,
                    InvolveGravity = false,
                    FinishWhenMax = false
                };
            }
        }

        public static BounceUpMotion MarioStamp
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.MarioBounce,
                    StartVelocity = new Vector2(0, -5.5f),
                    Acceleration = new Vector2(0, 0.5f),
                    MaxVelocity = GravityMotion.Max,
                    InvolveGravity = true,
                    FinishWhenMax = true
                };
            }
        }

        public static BounceUpMotion FireballBounce
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.FireballBounce,
                    StartVelocity = new Vector2(0, -2.7f),
                    Acceleration = new Vector2(0, 0.2f),
                    MaxVelocity = GravityMotion.Max,
                    InvolveGravity = true,
                    FinishWhenMax = true
                };
            }
        }

        public static BounceUpMotion EnemyFlip
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.EnemyFlip,
                    StartVelocity = new Vector2(0, -4),
                    Acceleration = new Vector2(0, 0.25f),
                    MaxVelocity = GravityMotion.Max,
                    InvolveGravity = true,
                    FinishWhenMax = true
                };
            }
        }

        public static BounceUpMotion CoinMotion
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.Coin,
                    StartVelocity = new Vector2(0, -10f),
                    Acceleration = new Vector2(0, 0.5f),
                    MaxVelocity = new Vector2(0, 6f),
                    InvolveGravity = false,
                    FinishWhenMax = true
                };
            }
        }

        public static BounceUpMotion StarMotion
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.Star,
                    StartVelocity = new Vector2(0, -7f),
                    Acceleration = new Vector2(0, 0.3f),
                    InvolveGravity = true,
                    MaxVelocity = GravityMotion.Max,
                    FinishWhenMax = false
                };
            }
        }

        public static BounceUpMotion BlockHit
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.BlockHit,
                    StartVelocity = new Vector2(0, -7.15f),
                    Acceleration = new Vector2(0, 1.591f),
                    InvolveGravity = false,
                    MaxVelocity = GravityMotion.Max,
                    FinishWhenMax = true
                };
            }
        }

        public static BounceUpMotion ItemBounce
        {
            get
            {
                return new BounceUpMotion
                {
                    version = Version.ItemBounce,
                    StartVelocity = new Vector2(0, -.05f),
                    Acceleration = new Vector2(0, 0.3f),
                    InvolveGravity = true,
                    MaxVelocity = GravityMotion.Max,
                    FinishWhenMax = false
                };
            }
        }
    }
}