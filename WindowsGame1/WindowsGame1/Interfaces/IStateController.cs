using System;

namespace WindowsGame1
{
    public interface IStateController
    {
        ICore Core { set; }
        ISpriteState GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }

        void RefreshState();
        void SwitchComponent(Object component);
    }
}