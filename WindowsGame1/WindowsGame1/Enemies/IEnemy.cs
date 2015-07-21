﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IEnemy : IObject
    {
        bool Alive { get; }

        bool isMovingShell { get; }
    }
}
