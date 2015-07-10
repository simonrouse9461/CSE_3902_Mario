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

        private Version version = Version.Default;
        public NormalBlockObject() {
            StateController.NormalBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        public NormalBlockObject CoinNormalBlock
        {
            get
            {
                version = Version.Coin;
                return this;
            }
        }

        public NormalBlockObject StarNormalBlock
        {
            get
            {
                version = Version.Star;
                return this;
            }
        }
    }
}
