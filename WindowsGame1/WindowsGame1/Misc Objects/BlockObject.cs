using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockObject : ObjectKernel<BlockSpriteEnum, ItemMotionEnum>
    {
        public BlockObject(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<BlockSpriteEnum, ItemMotionEnum>(default(Vector2));
            Sprites = new Dictionary<BlockSpriteEnum, ISprite>();
            Motions = new Dictionary<ItemMotionEnum, ObjectMotion>();

            Sprites.Add(BlockSpriteEnum.UsedBlock, new UsedBlockSprite());
            Sprites.Add(BlockSpriteEnum.QuestionBlock, new QuestionBlockSprite());
            Motions.Add(ItemMotionEnum.leftRight, new ObjectMotion());
            
        }
    }
}
