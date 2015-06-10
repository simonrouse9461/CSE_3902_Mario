using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GreenPipeObject : ObjectKernelNew<GreenPipeSpriteState, GreenPipeMotionState>
    {

        public GreenPipeObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new GreenPipeSpriteState();
            MotionState = new GreenPipeMotionState(location);
        }

        protected void Reset()
        {

        }
    }

}
