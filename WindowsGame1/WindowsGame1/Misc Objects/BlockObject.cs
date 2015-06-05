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
            Sprites.Add(BlockSpriteEnum.DestructibleBlock, new DestructibleBlockSprite());
            Sprites.Add(BlockSpriteEnum.HiddenBlock, new HiddenBlockSprite());
            Sprites.Add(BlockSpriteEnum.NormalBlock, new NormalBlockSprite());
            Sprites.Add(BlockSpriteEnum.IndestructibleBlock, new IndestructibleBlockSprite());
            Sprites.Add(BlockSpriteEnum.GreenPipe, new GreenPipeSprite());
            Motions.Add(BlockMotionEnum.upDown, new ObjectMotion());
            
        }
    }
}
