using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class StateKernel : IState
    {
        public Vector2 Location { get; set; }

        public Enum ActiveSprite { get; set; }

        public Dictionary<Enum, bool> EffectiveMotion { get; set; }

        protected StateKernel()
        {
            Location = default(Vector2);
            Initialize();
        }

        public abstract void Initialize();
    }
}