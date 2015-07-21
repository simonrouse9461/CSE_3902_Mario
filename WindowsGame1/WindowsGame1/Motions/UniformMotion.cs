using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class UniformMotion : MotionKernel
    {
        private enum Version
        {
            Default,
            EnemyLeft,
            EnemyRight,
            KoopaLeft,
            KoopaRight,
            MarioLeft,
            MarioRight,
            MarioSlip,
            MarioPipe,
            ItemLeft,
            ItemRight,
            ItemUp,
            FireballLeft,
            FireballRight
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
                var velocity = StartVelocity;
                return velocity;
            }
        }

        // Versions

        public static UniformMotion EnemyMoveLeft
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.EnemyLeft,
                    StartVelocity = new Vector2(-1, 0)
                };
            }
        }

        public static UniformMotion EnemyMoveRight
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.EnemyRight,
                    StartVelocity = new Vector2(1, 0)
                };
            }
        }

        public static UniformMotion KoopaShellLeft
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.KoopaLeft,
                    StartVelocity = new Vector2(-4, 0)
                };
            }
        }

        public static UniformMotion KoopaShellRight
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.KoopaRight,
                    StartVelocity = new Vector2(4, 0)
                };
            }
        }

        public static UniformMotion MarioSprintLeft
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.MarioLeft,
                    StartVelocity = new Vector2(-4.5f, 0)
                };
            }
        }

        public static UniformMotion MarioSlipDown
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.MarioSlip,
                    StartVelocity = new Vector2(0, -3)
                };
            }
        }

        public static UniformMotion MarioEnterPipe
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.MarioPipe,
                    StartVelocity = new Vector2(0, -0.5f)
                };
            }
        }

        public static UniformMotion MarioSpriteRight
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.MarioRight,
                    StartVelocity = new Vector2(4.5f, 0)
                };
            }
        }

        public static UniformMotion ItemMoveLeft
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.ItemLeft,
                    StartVelocity = new Vector2(-2, 0)
                };
            }
        }

        public static UniformMotion ItemMoveRight
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.ItemRight,
                    StartVelocity = new Vector2(2, 0)
                };
            }
        }

        public static UniformMotion ItemRaiseUp
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.ItemUp,
                    StartVelocity = new Vector2(0, -0.4f)
                };
            }
        }

        public static UniformMotion FireballMoveLeft
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.FireballLeft,
                    StartVelocity = new Vector2(-6, 0)
                };
            }
        }

        public static UniformMotion FireballMoveRight
        {
            get
            {
                return new UniformMotion
                {
                    version = Version.FireballRight,
                    StartVelocity = new Vector2(6, 0)
                };
            }
        }
    }
}