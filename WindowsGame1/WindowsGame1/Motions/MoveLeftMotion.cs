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

        public MoveLeftMotion EnemyVelocity
        {
            get
            {
                version = Version.Enemy;
                StartVelocity = new Vector2(-1, 0);
                return this;
            }
        }

        public MoveLeftMotion ItemVelocity
        {
            get
            {
                version = Version.Item;
                StartVelocity = new Vector2(-1, 0);
                return this;
            }
        }

        public MoveLeftMotion FireballVelocity
        {
            get
            {
                version = Version.Fireball;
                StartVelocity = new Vector2(-6, 0);
                return this;
            }
        }
    }
}