using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace SuperMario
{
    public class RestoringKoopaSprite : SpriteKernel
    {
        public RestoringKoopaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(330, 4, 16, 15), Orientation.Default},
                {new Rectangle(360, 5, 16, 14), Orientation.Default}
            });
            SetAnimation(new []
            {
                new SpriteTransformation(0), 
                new SpriteTransformation(1), 
                new SpriteTransformation(0), 
                new SpriteTransformation(1), 
                new SpriteTransformation(0), 
                new SpriteTransformation(1), 
                new SpriteTransformation(0), 
                new SpriteTransformation(0), 
            });
        }
    }
}
