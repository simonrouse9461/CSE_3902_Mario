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

        protected CollisionHandlerKernel(ICore core)
        {
            if (core is Core<TSpriteState, TMotionState>)
                Core = (Core<TSpriteState, TMotionState>) core;
            else
                Core = new Core<TSpriteState, TMotionState>
                {
                    Object = core.Object,
                    SpriteState = (TSpriteState) (core.GeneralSpriteState),
                    MotionState = (TMotionState) (core.GeneralMotionState),
                    CollisionHandler = core.CollisionHandler,
                    CommandExecutor = core.CommandExecutor,
                    BarrierDetector = core.BarrierDetector
                };
            Detector = new CollisionDetector(Core.Object);
        }

        public abstract void Handle();
    }
}