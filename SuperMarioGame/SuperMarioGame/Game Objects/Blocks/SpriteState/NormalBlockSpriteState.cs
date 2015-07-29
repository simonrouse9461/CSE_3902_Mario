using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class NormalBlockSpriteState : SpriteStateKernel<NormalBlockSpriteVersion>
    {

        private enum VersionAnimation
        {
            Overworld,
            Underworld
        }

        public NormalBlockSpriteState()
        {

            AddSprite<NormalBlockSprite>();
            AddVersionAnimator(VersionAnimation.Overworld,
            new[] {NormalBlockSpriteVersion.Overworld});
            AddVersionAnimator(VersionAnimation.Underworld,
            new[] {NormalBlockSpriteVersion.Underworld});
            SetVersionAnimator(VersionAnimation.Overworld);
        }


    }
}
