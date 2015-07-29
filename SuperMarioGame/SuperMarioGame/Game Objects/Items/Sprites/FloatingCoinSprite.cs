using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FloatingCoinSprite : SpriteKernel
    {

        public FloatingCoinSprite()
        {


            AddSource(
                "items",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(127, 94, 12, 16), Orientation.Default},
                    {new Rectangle(157, 94, 12, 16), Orientation.Default},
                    {new Rectangle(187, 94, 12, 16), Orientation.Default},
                    {new Rectangle(218, 94, 12, 16), Orientation.Default}
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
