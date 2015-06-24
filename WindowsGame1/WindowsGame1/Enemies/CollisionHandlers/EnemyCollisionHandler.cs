﻿using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class EnemyCollisionHandler : CollisionHandlerKernelNew<EnemySpriteState, EnemyMotionState>
    {
        public EnemyCollisionHandler(State<EnemySpriteState, EnemyMotionState> state) : base(state)
        {
            AddBarrier<IObject>();
        }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.Solid && mario.Alive).Top.Contact)
            {
                State.SpriteState.MarioSmash();
            }
        }
    }
}