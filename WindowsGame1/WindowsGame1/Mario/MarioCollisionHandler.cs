using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector<GreenPipeObject> MarioPipeCollision;
        private CollisionDetector<Fireflower> MarioFireflowerCollision;
        private CollisionDetector<Mushroom> MarioMushroomCollision;
        private CollisionDetector<Goomba> MarioGoombaCollision;
        private CollisionDetector<IObject> MarioObjectCollision;

        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioPipeCollision = new CollisionDetector<GreenPipeObject>(Object);
            MarioFireflowerCollision = new CollisionDetector<Fireflower>(Object);
            MarioMushroomCollision = new CollisionDetector<Mushroom>(Object);
            MarioGoombaCollision = new CollisionDetector<Goomba>(Object);
            MarioObjectCollision = new CollisionDetector<IObject>(Object);

        }

        public override void Handle()
        {
            if (SpriteState.IsDead())
                return;

            if (MarioPipeCollision.Detect().Side())
            {
                SpriteState.BecomeDead();
            }
            if (MarioFireflowerCollision.Detect().Side())
            {
                SpriteState.BecomeFire();
            }
            if (MarioMushroomCollision.Detect().Side())
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

            if (MarioObjectCollision.Detect().Any())
            {
                while (MarioObjectCollision.Detect().Bottom)
                {
                    MotionState.Up1();
                }
                while (MarioObjectCollision.Detect().Top)
                {
                    MotionState.Down1();
                }
                while (MarioObjectCollision.Detect().Left)
                {
                    MotionState.Right1();
                }
                while (MarioObjectCollision.Detect().Right)
                {
                    MotionState.Left1();
                }
            }

        }
    }
}