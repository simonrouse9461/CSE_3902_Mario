using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballSpriteState : SpriteStateKernelNew<SuperFireballSpriteVersion>
    {

        public SuperFireballSpriteState()
        {
            AddSprite<SuperFireballSprite>();
            SetSprite<SuperFireballSprite>();
            SetSpriteFrequency(5);
        }

        

    }
}
