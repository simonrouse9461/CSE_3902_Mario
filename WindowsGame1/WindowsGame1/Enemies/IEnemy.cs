using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public interface IEnemy : IObject
    {
        bool Alive { get; }
    }
}
