using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class UsedBlockSpriteState : SpriteStateKernelNew<UsedBlockSpriteVersion>
    {

        private enum VersionAnimator
        {
            Overworld,
            Underworld
        }

        public UsedBlockSpriteState()
        {
            AddSprite<UsedBlockSprite>();
            AddVersionAnimator(VersionAnimator.Overworld,
                new[] { UsedBlockSpriteVersion.UsedOver});
            AddVersionAnimator(VersionAnimator.Underworld,
                new[] { UsedBlockSpriteVersion.UsedUnder });
        }

    }
}
