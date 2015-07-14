using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class OneUpBarrierHandler : BarrierHandlerKernel<OneUpStateController>
    {

        public OneUpBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision()
        {
            
        }
    }
}
