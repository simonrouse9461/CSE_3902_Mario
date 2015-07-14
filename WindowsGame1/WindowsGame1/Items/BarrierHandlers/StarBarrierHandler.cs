using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class StarBarrierHandler : BarrierHandlerKernel<StarStateController>
    {

        public StarBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision()
        {
            
        }

    }
}
