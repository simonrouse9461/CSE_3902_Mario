using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public abstract class EnemySpriteState : SpriteStateKernelNew<int>
    {
        public abstract void MarioSmash();

        public abstract bool Dead { get; }

        public abstract void Turn();
    }
}
