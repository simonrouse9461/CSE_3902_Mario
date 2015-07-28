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
            AddMotion<GravityMotion>();
        }

        public void BounceUp()
        {
            TurnOnMotion<BounceUpMotion>();
            TurnOnMotion<GravityMotion>();
        }

        public void StopFall()
        {
            TurnOffMotion<GravityMotion>();
        }

        public bool IsHit
        {
            get { return CheckMotion<BounceUpMotion>() || CheckMotion<GravityMotion>(); }
        }
    }
}
