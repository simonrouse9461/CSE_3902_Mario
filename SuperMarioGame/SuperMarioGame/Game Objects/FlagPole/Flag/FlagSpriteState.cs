using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FlagSpriteState : SpriteStateKernel<int>
    {
        public FlagSpriteState()
        {
            AddSprite<FlagSprite>();
            SetSprite<FlagSprite>();
        }
    }
}
