using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class CoinCollisionHandler : CollisionHandlerKernelNew<CoinStateController>
    {

        public CoinCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            HandleMario();
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<Mario>().AnySide.Touch)
            {
                Core.Object.Unload();
                Display.AddScore<Coin>();
            }
        }
    }
}
