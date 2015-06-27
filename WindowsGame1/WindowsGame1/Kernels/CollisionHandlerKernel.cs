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
        public State<TSpriteState, TMotionState> State { get; set; }
        public CollisionDetector Detector { get; set; }

        protected CollisionHandlerKernel(State<TSpriteState,TMotionState> state)
        {
            State = state;
            Detector = new CollisionDetector(State.Object);
        }

        public abstract void Handle();
    }
}