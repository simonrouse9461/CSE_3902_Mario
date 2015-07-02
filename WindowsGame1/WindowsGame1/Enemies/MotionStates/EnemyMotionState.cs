using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public abstract class EnemyMotionState : MotionStateKernel
    {
        public abstract void MarioSmash(string s = "");

        public abstract void Turn();
    }
}
