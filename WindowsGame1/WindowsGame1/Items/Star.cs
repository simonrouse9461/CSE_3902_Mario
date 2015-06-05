using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Star : ObjectKernel<StarSpriteEnum, StarMotionEnum>
    {
        public Star(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<StarSpriteEnum, StarMotionEnum>(default(Vector2));
            Sprites = new Dictionary<StarSpriteEnum, ISprite>();
            Motions = new Dictionary<StarMotionEnum, ObjectMotion>();

            Sprites.Add(StarSpriteEnum.Star, new StarSprite());
        }
        protected void Reset()
        {

        }
    }
}
