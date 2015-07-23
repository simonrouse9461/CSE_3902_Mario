using SuperMario;

namespace SuperMario
{
    public class BlockDebrisSpriteState : SpriteStateKernelNew<BlockDebrisSpriteVersion>
    {
        public BlockDebrisSpriteState()
        {
            AddSprite<BlockDebrisSprite>();
            SetSprite<BlockDebrisSprite>();
            SetSpriteFrequency(5);
        }
    }
}