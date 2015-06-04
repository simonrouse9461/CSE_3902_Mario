using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernel<ItemSpriteEnum, ItemMotionEnum>
    {
        public Mushroom(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<ItemSpriteEnum, ItemMotionEnum>(default(Vector2));
            Sprites = new Dictionary<ItemSpriteEnum, ISprite>();
            Motions = new Dictionary<ItemMotionEnum, ObjectMotion>();

            Sprites.Add(ItemSpriteEnum.Mushroom, new MushroomSprite());
            Sprites.Add(ItemSpriteEnum.Fireflower, new FireflowerSprite());
            Motions.Add(ItemMotionEnum.leftRight, new ObjectMotion());

        }
        protected void Reset()
        {

        }
    }
}
