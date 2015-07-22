using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class QuestionBlockSprite : SpriteKernelNew
    {
        public QuestionBlockSprite()
            : base(QuestionBlockSpriteVersion.YellowOver)
        {

            AddSource(
                QuestionBlockSpriteVersion.YellowOver,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(372, 160, 16, 16), Orientation.Default}   
                });
            AddSource(
                QuestionBlockSpriteVersion.OrangeOver,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                   {new Rectangle(390, 160, 16, 16), Orientation.Default}
                });
            AddSource(
                QuestionBlockSpriteVersion.BrownOver,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(408, 160, 16, 16), Orientation.Default}
                });

            AddSource(
                QuestionBlockSpriteVersion.YellowUnder,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(372, 179, 16, 16), Orientation.Default}
                }
                );

            AddSource(
                QuestionBlockSpriteVersion.OrangeUnder,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(390, 179, 16, 16), Orientation.Default}
                }
                );

            AddSource(
                QuestionBlockSpriteVersion.BrownUnder,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(408, 179, 16, 16), Orientation.Default}
                }
                );
        }        
    }
}
