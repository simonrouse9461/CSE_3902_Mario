using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : BlockKernel, IBlock
    {
        private enum Version
        {
            Default,
            Coin,
            Star
        }

        public bool giveStar { get; set; }
        public bool giveCoin { get; set; }
        private Version version;

        public NormalBlockObject()
        {
            StateController.NormalBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        public static NormalBlockObject CoinNormalBlock
        {
            get
            {
                return new NormalBlockObject
                {
                    version = Version.Coin
                };
            }
        }
    }
}
