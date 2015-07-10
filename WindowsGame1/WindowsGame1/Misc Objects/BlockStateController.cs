using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockStateController : StateControllerKernel<BlockSpriteState, BlockMotionState>
    {

        public void QuestionBlock()
        {
            SpriteState.QuestionBlock();
        }

        public void HiddenBlock()
        {
            SpriteState.HiddenBlock();
        }

        public void NormalBlock()
        {
            SpriteState.NormalBlock();
        }

        public void FloorBlock()
        {
            SpriteState.FloorBlock();
        }

        public void IndestructibleBlock()
        {
            SpriteState.Indestructible();
        }
    }
}
