using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class FireballSpriteState : SpriteStateKernelNew<int>
    {
        public FireballSpriteState()
        {
            AddSprite<RotatingFireballSprite>();
            AddSprite<ExplodingFireballSprite>();

            SetSprite<RotatingFireballSprite>();
            SetSpriteFrequency(5);
        }

        public void Rotate()
        {
            SetSprite<RotatingFireballSprite>();
        }

        public void Explode()
        {
            SetSprite<ExplodingFireballSprite>();
        }

        public bool Rotating
        {
            get { return IsSprite<RotatingFireballSprite>();}
        }

        public bool Exploding
        {
            get { return IsSprite<ExplodingFireballSprite>(); }
        }
    }
}
