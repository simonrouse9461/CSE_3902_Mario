using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class BlockMotionState : MotionStateKernelNew
    {
        public BlockMotionState()
        {
            AddMotion(BounceUpMotion.BlockHit);
        }

        public void Hit()
        {
            TurnOnMotion<BounceUpMotion>();
        }

        public bool isHit
        {
            get { return CheckMotion<BounceUpMotion>(); }
        }
    }
}
