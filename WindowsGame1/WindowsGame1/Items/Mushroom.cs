using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernel<MushroomSpriteEnum, MushroomMotionEnum>
    {
        public Mushroom(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<MushroomSpriteEnum, MushroomMotionEnum>(default(Vector2));
            Sprites = new Dictionary<MushroomSpriteEnum, ISprite>();
            Motions = new Dictionary<MushroomMotionEnum, ObjectMotion>();

            Sprites.Add(MushroomSpriteEnum.Mushroom, new MushroomSprite());
            Motions.Add(MushroomMotionEnum.leftRight, new ObjectMotion());

        }
        protected void Reset()
        {

        }
    }
}
