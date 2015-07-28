using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class FireflowerSprite : SpriteKernelNew
    {
        public FireflowerSprite()
        {
            const int period = 4;
            AddSource(
                "items",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(3, 64, 17, 18), Orientation.Default},
                    {new Rectangle(33, 64, 17, 18), Orientation.Default},
                    {new Rectangle(63, 64, 17, 18), Orientation.Default},
                    {new Rectangle(93, 64, 17, 18), Orientation.Default}
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
