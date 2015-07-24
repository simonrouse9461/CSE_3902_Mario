using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class CastleSpriteState : SpriteStateKernelNew<CastleSpriteVersion>
    {

        public CastleSpriteState()
        {

            AddSprite<CastleSprite>();
        }

        public void SetCastle()
        {
            SetSprite<CastleSprite>();
        }
    }
}
