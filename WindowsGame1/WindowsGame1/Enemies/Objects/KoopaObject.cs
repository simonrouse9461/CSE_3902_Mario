using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernelNew<KoopaSpriteState, KoopaMotionState>
    {
        public  Koopa(Vector2 location) : base(location) { }


        protected override void Initialize(Vector2 location)
        {
            SpriteState = new KoopaSpriteState();
            MotionState = new KoopaMotionState(location);

        }

        protected void Reset(Vector2 location)
        {
            SpriteState = new KoopaSpriteState();
            MotionState = new KoopaMotionState(location);
        }
    }
}
