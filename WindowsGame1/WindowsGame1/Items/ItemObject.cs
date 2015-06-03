using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class ItemObject : ObjectKernel<ItemSpriteEnum, ItemMotionEnum>
    {
        public ItemObject(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<ItemSpriteEnum, ItemMotionEnum>(default(Vector2));
            Sprites = new Dictionary<ItemSpriteEnum, ISprite>();
            Motions = new Dictionary<ItemMotionEnum, ObjectMotion>();

            Sprites.Add(ItemSpriteEnum.UsedBlock, new UsedBlockSprite());
            Sprites.Add(ItemSpriteEnum.QuestionBlock, new QuestionBlockSprite());
            Motions.Add(ItemMotionEnum.upDown, new ObjectMotion());

        }
    }
}
