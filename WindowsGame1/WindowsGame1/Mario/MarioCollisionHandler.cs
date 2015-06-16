using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector<GreenPipeObject> MarioPipeCollision;

        public MarioCollisionHandler(IObject obj) : base(obj) { }

        protected override void Initialize()
        {
            MarioPipeCollision = new CollisionDetector<GreenPipeObject>(Object);
        }

        public override List<Action<MarioSpriteState, MarioMotionState>> GetAction()
        {
            var list = new List<Action<MarioSpriteState, MarioMotionState>>();
            if (MarioPipeCollision.Detect().Side())
            {
                list.Add((spriteState, motionState) => spriteState.BecomeDead());
            }
            return list;
        }
    }
}