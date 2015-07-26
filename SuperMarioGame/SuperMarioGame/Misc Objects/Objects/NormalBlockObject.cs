using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class NormalBlockObject : BlockKernel
    {

        public NormalBlockObject()
        {
            StateController.NormalBlock();
            CollisionHandler = new NormalBlockCollisionHandler(Core);
        }

        public static NormalBlockObject CoinNormalBlock
        {
            get
            {
                var instance = new NormalBlockObject();
                instance.Core.StateController.PutCoin();
                return instance;
            }
        }

        public static NormalBlockObject StarNormalBlock
        {
            get
            {
                var instance = new NormalBlockObject();
                instance.Core.StateController.PutStar();
                return instance;
            }
        }

        public bool isHit
        {
            get
            {
                return Core.CollisionDetector.Detect<MarioObject>().Bottom.Touch;
            }
        }
    }
}
