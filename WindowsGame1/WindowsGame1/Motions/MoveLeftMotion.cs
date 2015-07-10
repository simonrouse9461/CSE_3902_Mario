using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MoveLeftMotion : MotionKernel
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

        public static MoveLeftMotion EnemyVelocity
        {
            get
            {
                return new MoveLeftMotion
                {
                    version = Version.Enemy,
                    StartVelocity = new Vector2(-1, 0)
                };
            }
        }

        public static MoveLeftMotion ItemVelocity
        {
            get
            {
                return new MoveLeftMotion
                {
                    version = Version.Item,
                    StartVelocity = new Vector2(-1, 0)
                };
            }
        }

        public MoveLeftMotion FireballVelocity
        {
            get
            {
                return new MoveLeftMotion
                {
                    version = Version.Fireball,
                    StartVelocity = new Vector2(-6, 0)
                };
            }
        }
    }
}