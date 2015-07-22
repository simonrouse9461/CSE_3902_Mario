using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class FloatingCoinCollisionHandler : CollisionHandlerKernel<FloatingCoinStateController>
    {
        public FloatingCoinCollisionHandler(ICore core) : base(core) { }


        public override void Handle()
        {
            HandleMario();
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<MarioObject>().AnySide.Touch)
            {
                Core.Obj.Unload();
                Display.AddScore<Coin>();
            }
        }
    }
}
