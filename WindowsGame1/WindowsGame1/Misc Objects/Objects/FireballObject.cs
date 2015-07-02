using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballObject : ObjectKernel<FireballSpriteState, FireballMotionState>
    {

        protected override void SyncState()
        {
            if (SpriteState.Left)
            {
                MotionState.Left();
            }
            if (SpriteState.Right)
            {
                MotionState.Right();
            }
        }
        public override bool Solid
        {
            get { return true; }
        }
    }
}
