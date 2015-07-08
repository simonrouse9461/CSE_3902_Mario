﻿using System;

namespace WindowsGame1
{
    public interface IStateController
    {
        ICore Core { set; }
        ISpriteState GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }

        void Update();
        void SwitchComponent(Object component);
    }
}