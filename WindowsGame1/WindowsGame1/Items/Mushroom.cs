using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernel<MushroomSpriteState, RightMotionState>
    {
        public Mushroom(Vector2 location) : base(location) { }


        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MushroomSpriteState();
            MotionState = new RightMotionState(location);
        }
        public override void Reset(Vector2 location)
        {
            SpriteState = new MushroomSpriteState();
            MotionState = new RightMotionState(location);
        }
    }
}
