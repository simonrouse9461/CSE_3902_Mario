using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernel<CoinSpriteState, BlankMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new CoinSpriteState();
            MotionState = new BlankMotionState();
        }
    }
}
