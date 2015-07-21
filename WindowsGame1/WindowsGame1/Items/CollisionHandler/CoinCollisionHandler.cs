using System;
using System.Collections.Generic;

namespace MarioGame
{
    public class CoinCollisionHandler : CollisionHandlerKernel<CoinStateController>
    {

        public CoinCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            HandleMario();
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<MarioObject>().AnySide.Touch)
            {
                Core.Object.Unload();
                Display.AddScore<Coin>();
            }
        }
    }
}
