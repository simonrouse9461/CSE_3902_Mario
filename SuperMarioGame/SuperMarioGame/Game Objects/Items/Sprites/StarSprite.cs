using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class StarSprite : SpriteKernel
    {
        public StarSprite()
        {
            AddSource(
                "items",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(5, 94, 14, 16), Orientation.Default},
                    {new Rectangle(35, 94, 14, 16), Orientation.Default},
                    {new Rectangle(65, 94, 14, 16), Orientation.Default},
                    {new Rectangle(95, 94, 14, 16), Orientation.Default}
                });
            SetAnimation(
                new[] {
                    new SpriteTransformation(0),
                    new SpriteTransformation(1),
                    new SpriteTransformation(2),
                    new SpriteTransformation(3)
                });      
        }
    }
}
