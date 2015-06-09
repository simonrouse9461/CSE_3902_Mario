using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : ObjectKernelNew<HiddenBlockSpriteState, HiddenBlockMotionState>
    {

        public HiddenBlockObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new HiddenBlockSpriteState();
            MotionState = new HiddenBlockMotionState(location);
        }

        protected void Reset()
        {

        }
    }

}
