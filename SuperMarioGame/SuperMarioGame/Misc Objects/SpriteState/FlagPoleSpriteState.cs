using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FlagPoleSpriteState : SpriteStateKernelNew<FlagPoleSpriteVersion>
    {

        public FlagPoleSpriteState()
        {
            AddSprite<FlagPoleSprite>();
        }

        public void SetFlagPole()
        {
            SetSprite<FlagPoleSprite>();
        }
    }
}
