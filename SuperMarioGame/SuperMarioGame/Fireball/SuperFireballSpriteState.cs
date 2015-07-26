using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballSpriteState : SpriteStateKernelNew<int>
    {
        public SuperFireballSpriteState()
        {
            AddSprite<FlyingSuperFireballSprite>();
            AddSprite<ExplodingSuperFireballSprite>();
            SetSprite<FlyingSuperFireballSprite>();
            SetSpriteFrequency(5);
        }

        public void Explode()
        {
            SetSprite<ExplodingSuperFireballSprite>();
        }
    }
}
