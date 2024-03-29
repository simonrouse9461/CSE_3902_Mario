﻿using System;

namespace SuperMario
{
    public interface IStateController
    {
        ICore Core { set; }
        ISpriteState GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }

        void Update();
        void RefreshState();
        void SwitchComponent(object component);
    }
}