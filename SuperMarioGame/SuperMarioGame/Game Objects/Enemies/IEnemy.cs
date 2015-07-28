using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public interface IEnemy : IObject
    {
        bool Alive { get; }
    }
}
