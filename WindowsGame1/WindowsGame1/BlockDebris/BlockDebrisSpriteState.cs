using MarioGame;

namespace MarioGame
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