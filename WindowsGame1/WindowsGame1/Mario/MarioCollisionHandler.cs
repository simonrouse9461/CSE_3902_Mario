using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector<GreenPipeObject> MarioPipeCollision;
        private CollisionDetector<Fireflower> MarioFireflowerCollision;
        private CollisionDetector<Mushroom> MarioMushroomCollision;

        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioPipeCollision = new CollisionDetector<GreenPipeObject>(Object);
            MarioFireflowerCollision = new CollisionDetector<Fireflower>(Object);
            MarioMushroomCollision = new CollisionDetector<Mushroom>(Object);
        }

        public override void Handle()
        {
            if (MarioPipeCollision.Detect().Side())
            {
                SpriteState.BecomeDead();
                MotionState.Dead();
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
        }
    }
}