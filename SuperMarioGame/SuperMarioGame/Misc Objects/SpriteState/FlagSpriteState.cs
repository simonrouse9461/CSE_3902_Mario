using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FlagSpriteState : SpriteStateKernelNew<FlagSpriteVersion>
    {

        public FlagSpriteState()
        {
            AddSprite<FlagSprite>();
        }

        public void SetFlag()
        {
            SetSprite<FlagSprite>();
        }
    }
}
