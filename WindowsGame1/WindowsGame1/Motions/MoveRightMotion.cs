using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MoveRightMotion : MotionKernel
    {
        private Vector2 StartVelocity;

        private enum Version
        {
            Default,
            Enemy,
            Item,
            Fireball
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

        public static MoveRightMotion EnemyVelocity
        {
            get
            {
                return new MoveRightMotion
                {
                    version = Version.Enemy,
                    StartVelocity = new Vector2(1, 0)
                };
            }
        }

        public static MoveRightMotion ItemVelocity
        {
            get
            {
                return new MoveRightMotion
                {
                    version = Version.Item,
                    StartVelocity = new Vector2(1, 0)
                };
            }
        }

        public static MoveRightMotion FireballVelocity
        {
            get
            {
                return new MoveRightMotion
                {
                    version = Version.Fireball,
                    StartVelocity = new Vector2(6, 0)
                };
            }
        }
    }
}