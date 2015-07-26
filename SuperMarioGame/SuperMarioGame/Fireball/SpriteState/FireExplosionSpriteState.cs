using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FireExplosionSpriteState : SpriteStateKernelNew<int>
    {
        public ExplosionSize Size { get; set; }

        public FireExplosionSpriteState()
        {
            AddSprite<ExplodingTinyFireballSprite>();
            AddSprite<ExplodingSmallFireballSprite>();
            AddSprite<ExplodingMediumFireballSprite>();
            AddSprite<ExplodingLargeFireballSprite>();

            SetSpriteFrequency(5);
        }

        public void SetSize(ExplosionSize size)
        {
            Size = size;
            switch (size)
            {
                case ExplosionSize.Large:
                    SetSprite<ExplodingLargeFireballSprite>();
                    break;
                case ExplosionSize.Medium:
                    SetSprite<ExplodingMediumFireballSprite>();
                    break;
                case ExplosionSize.Small:
                    SetSprite<ExplodingSmallFireballSprite>();
                    break;
                case ExplosionSize.Tiny:
                    SetSprite<ExplodingTinyFireballSprite>();
                    break;
            }
        }
    }
}
