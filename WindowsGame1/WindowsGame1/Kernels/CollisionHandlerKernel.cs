using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TSpriteState, TMotionState> : ICollisionHandler
        where TSpriteState : SpriteStateKernel
        where TMotionState : MotionStateKernel
    {
        public Core<TSpriteState, TMotionState> Core { get; set; }
        public CollisionDetector Detector { get; set; }

        protected CollisionHandlerKernel(Core<TSpriteState,TMotionState> core)
        {
            Core = core;
            Detector = new CollisionDetector(Core.Object);
        }

        public abstract void Handle();
    }
}