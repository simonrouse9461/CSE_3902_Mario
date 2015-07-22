﻿using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class FlagStateController : StateControllerKernelNew<FlagSpriteState, StaticMotionState>
    {

        public void Flag()
        {

            SpriteState.SetFlag();
        }

    }
}