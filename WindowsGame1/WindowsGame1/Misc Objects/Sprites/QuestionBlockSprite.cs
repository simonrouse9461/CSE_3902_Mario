using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class QuestionBlockSprite : SpriteKernelNew
    {
        public QuestionBlockSprite()
            : base(BlockSpriteVersion.BlockVersion.Overworld)
        {

            AddSource(
                BlockSpriteVersion.BlockVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(372, 160, 16, 16), Orientation.Default},
                    {new Rectangle(390, 160, 16, 16), Orientation.Default},
                    {new Rectangle(409, 160, 16, 16), Orientation.Default}
                });

            AddSource(
                BlockSpriteVersion.BlockVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(372, 179, 16, 16), Orientation.Default},
                    {new Rectangle(390, 179, 16, 16), Orientation.Default},
                    {new Rectangle(409, 179, 16, 16), Orientation.Default}
                }
                );
        }        
    }
}
