using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector<Fireflower> MarioFireflowerCollision;
        private CollisionDetector<Mushroom> MarioMushroomCollision;
        private CollisionDetector<Goomba> MarioGoombaCollision;
        private CollisionDetector<IObject> MarioObjectCollision;

        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioFireflowerCollision = new CollisionDetector<Fireflower>(Object);
            MarioMushroomCollision = new CollisionDetector<Mushroom>(Object);
            MarioGoombaCollision = new CollisionDetector<Goomba>(Object);
            MarioObjectCollision = new CollisionDetector<IObject>(Object);
        }

        public override void Handle()
        {
            if (SpriteState.IsDead())
                return;

            if (MarioFireflowerCollision.Detect().Any())
            {
                SpriteState.BecomeFire();
            }
            if (MarioMushroomCollision.Detect().Any())
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeBig();
                }
            }
            if (MarioGoombaCollision.Detect().Side())
            {
                if (SpriteState.IsSmall())
                {
                    SpriteState.BecomeDead();
                    return;
                }
                if (SpriteState.IsBig() || SpriteState.IsFire())
                {
                    SpriteState.BecomeSmall();
                }
            }
        }

        public override void Adjust()
        {
            if (MarioObjectCollision.Detect().Any())
            {
                while (MarioObjectCollision.Detect(0).Bottom)
                {
                    MotionState.Up1();
                }
                while (MarioObjectCollision.Detect(0).Top)
                {
                    MotionState.Down1();
                }
                while (MarioObjectCollision.Detect(0).Left)
                {
                    MotionState.Right1();
                }
                while (MarioObjectCollision.Detect(0).Right)
                {
                    MotionState.Left1();
                }
            }
        }
    }
}