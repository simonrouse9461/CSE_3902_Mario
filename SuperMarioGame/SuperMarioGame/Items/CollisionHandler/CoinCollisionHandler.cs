using System;
using System.Collections.Generic;

namespace SuperMario
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
            if (Core.CollisionDetector.Detect<Mario>().AnySide.Touch)
            {
                Core.Obj.Unload();
                Display.AddScore<Coin>();
            }
        }
    }
}
