using SuperMario;

namespace SuperMario
{
    public class BlockDebrisSpriteState : SpriteStateKernel<BlockDebrisSpriteVersion>
    {
        public BlockDebrisSpriteState()
        {
            AddSprite<BlockDebrisSprite>();
            SetSprite<BlockDebrisSprite>();
            SetSpriteFrequency(5);
        }
    }
}