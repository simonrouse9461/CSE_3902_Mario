using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class SuperFireballSpriteState : SpriteStateKernelNew<SuperFireballSpriteVersion>
    {

        private enum VersionAnimation
        {
            Left,
            Right
        }

        public SuperFireballSpriteState()
        {
            AddSprite<SuperFireballSprite>();

            AddVersionAnimator(VersionAnimation.Left,
                new[] { SuperFireballSpriteVersion.Left });
            AddVersionAnimator(VersionAnimation.Right,
                new[] { SuperFireballSpriteVersion.Right });
        }

        

    }
}
