using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{

    public class _1up : ObjectKernel<_1upSpriteEnum, MushroomMotionEnum>
    {
        public _1up(Vector2 location) : base(location) { }

        protected override void Initialize()
        {
            State = new ObjectState<_1upSpriteEnum, MushroomMotionEnum>(default(Vector2));
            Sprites = new Dictionary<_1upSpriteEnum, ISprite>();
            Motions = new Dictionary<MushroomMotionEnum, ObjectMotion>();

            Sprites.Add(_1upSpriteEnum._1up, new _1upSprite());
            Motions.Add(MushroomMotionEnum.leftRight, new ObjectMotion());

        }
        protected void Reset()
        {

        }
   }
}
