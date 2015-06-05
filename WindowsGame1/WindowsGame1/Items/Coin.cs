using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Coin : ObjectKernel<CoinSpriteEnum, CoinMotionEnum>
    {
        public Coin(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<CoinSpriteEnum, CoinMotionEnum>(default(Vector2));
            Sprites = new Dictionary<CoinSpriteEnum, ISprite>();
            Motions = new Dictionary<CoinMotionEnum, ObjectMotion>();

            Sprites.Add(CoinSpriteEnum.Coin, new CoinSprite());
        }
        protected void Reset()
        {

        }
    }
}
