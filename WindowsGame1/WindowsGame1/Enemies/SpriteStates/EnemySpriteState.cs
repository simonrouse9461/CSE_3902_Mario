﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public abstract class EnemySpriteState : SpriteStateKernelNew
    {
        public abstract void MarioSmash();

        public abstract bool Dead { get; }
    }
}
