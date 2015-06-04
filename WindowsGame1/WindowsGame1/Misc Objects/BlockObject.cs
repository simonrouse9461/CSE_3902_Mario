using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    

    public class BlockObject : ObjectKernel<BlockSpriteEnum, BlockMotionEnum>
    {
        public BlockObject(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<BlockSpriteEnum, BlockMotionEnum>(default(Vector2));
            Sprites = new Dictionary<BlockSpriteEnum, ISprite>();
            Motions = new Dictionary<BlockMotionEnum, ObjectMotion>();

            Sprites.Add(BlockSpriteEnum.QuestionBlock, new QuestionBlockSprite());
            Sprites.Add(BlockSpriteEnum.UsedBlock, new UsedBlockSprite());
            Motions.Add(BlockMotionEnum.upDown, new ObjectMotion());
            
        }
    }
}
