using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernel<GoombaSpriteState, GoombaMotionState>
    {
        private CollisionDetector<MarioObject> GoombaMarioCollision;

        public GoombaCollisionHandler(IObject obj) : base(obj) { }

        protected override void Initialize()
        {
            GoombaMarioCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override List<Action<GoombaSpriteState, GoombaMotionState>> GetAction()
        {
            var list = new List<Action<GoombaSpriteState, GoombaMotionState>>();
            if (GoombaMarioCollision.Detect().Top)
            {
                list.Add((spriteState, motionState) => spriteState.BecomeDead());
            }
            return list;
        }
    }
}