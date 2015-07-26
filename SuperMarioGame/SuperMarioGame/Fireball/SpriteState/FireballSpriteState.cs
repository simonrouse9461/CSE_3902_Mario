using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FireballSpriteState : SpriteStateKernelNew<int>
    {
        public FireballSpriteState()
        {
            AddSprite<RotatingFireballSprite>();
            AddSprite<ExplodingTinyFireballSprite>();

            SetSprite<RotatingFireballSprite>();
            SetSpriteFrequency(5);
        }

        public void Rotate()
        {
            SetSprite<RotatingFireballSprite>();
        }

        public void Explode()
        {
            SetSprite<ExplodingTinyFireballSprite>();
        }

        public bool Rotating
        {
            get { return IsSprite<RotatingFireballSprite>();}
        }

        public bool Exploding
        {
            get { return IsSprite<ExplodingTinyFireballSprite>(); }
        }
    }
}
