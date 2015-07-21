using System;

namespace MarioGame
{
    public interface IStateController
    {
        ICore Core { set; }
        ISpriteState GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }

        void Update();
        void RefreshState();
        void SwitchComponent(Object component);
    }
}