﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballCollisionHandler : CollisionHandlerKernelNew<SuperFireballStateController>
    {

        public SuperFireballCollisionHandler(ICoreNew core) : base(core) {}

        public override void Handle()
        {          
            HandleObject();
        }

        protected virtual void HandleObject()
        {
            if (Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive).AnyEdge.Touch)
            {
                Core.Object.Generate(FireExplosion.Single(ExplosionSize.Medium));
            }
        }
    }
}
