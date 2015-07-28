using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FlagSpriteState : SpriteStateKernelNew<int>
    {
        public FlagSpriteState()
        {
            AddSprite<FlagSprite>();
            SetSprite<FlagSprite>();
        }
    }
}
